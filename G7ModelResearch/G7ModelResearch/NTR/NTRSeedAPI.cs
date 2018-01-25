using System;
using System.Linq;
using System.Threading;

namespace G7ModelResearch
{
    public partial class NtrClient
    {
        public byte Gameversion { get; private set; }
        public byte Pid { get; private set; } = 0x28;
        private uint NfcOffset;
        private bool DataReady;
        public byte[] Data { get; private set; }

        public class InfoEventArgs : EventArgs
        {
            public string info;
            public object data;
        }
        public event EventHandler<InfoEventArgs> Message;
        protected virtual void SendMsg(InfoEventArgs e) => Message?.Invoke(this, e);
        private object MsgLock = new object();
        private void SendMsg(object _data, string _info = null)
            => SendMsg(new InfoEventArgs { info = _info, data = _data });

        private void parseLogMsg(string logmsg)
        {
            getGame(logmsg);
            getBP(logmsg);
        }

        private static string[] pnamestr = { "niji_loc", "niji_loc", "momiji", "momiji" };
        private static string[] titleidstr = { "175e00", "1b5100" };
        
        // Debugger
        public void Disable() { bpdis(2); bpdis(3); bpdis(4); resume(); }
        public void Enable() { bpena(2); bpena(3); bpdis(4); }
        private uint FrameOffset;
        private uint BlinkOffset;
        private uint SyncOffset;

        private bool getGame(string logmsg)
        {
            string pname;
            if (null == (pname = pnamestr.FirstOrDefault(logmsg.Contains)))
                return false;
            Gameversion = (byte)Array.IndexOf(pnamestr, pname);
            pname = ", pname:" + pname.PadLeft(9);
            string pidaddr = logmsg.Substring(logmsg.IndexOf(pname, StringComparison.Ordinal) - 10, 10);
            Pid = Convert.ToByte(pidaddr, 16);
            if (titleidstr.Any(logmsg.Contains)) // Moon or UM
                Gameversion++;
            switch (Gameversion)
            {
                case 0:
                case 1:
                    NfcOffset = 0x3E14C0;
                    FrameOffset = 0x3A3C8C; BlinkOffset = 0x40F3B0; SyncOffset = 0x399650;
                    break;
                case 2:
                case 3:
                    NfcOffset = Gameversion == 2 ? 0x3F341Cu : 0x3F3420u;
                    FrameOffset = 0x3B2C10; BlinkOffset = 0x421E4C; SyncOffset = 0x3A7FE0;
                    break;
            }
            DebuggerMode();
            SendMsg(Gameversion, "Version");
            return true;
        }

        // Gen7 Connection Patch
        private const uint nfcVal = 0xE3A01000;
        private void WriteWifiPatch()
        {
            byte[] command = BitConverter.GetBytes(nfcVal);
            Write(NfcOffset, command, Pid);
            SendMsg("NFC Patched!");
        }

        private bool getBP(string logmsg)
        {
            if (!(logmsg.Contains("breakpoint ") && logmsg.Contains(" hit")))
                return false;
            string[] varname = { " lr:", "r0:" };
            uint[] output = new uint[3];
            output[0] = Convert.ToUInt32(logmsg.Substring(logmsg.IndexOf("breakpoint ", StringComparison.Ordinal) + "breakpoint ".Length, 1));
            for (int i = 0; i < varname.Length; i++)
            {
                var bpid = varname[i];
                string splitlog = "0x" + logmsg.Substring(logmsg.IndexOf(bpid, StringComparison.Ordinal) + bpid.Length, 8);
                output[i + 1] = Convert.ToUInt32(splitlog, 16);
            }
            uint address = output[1];
            switch (address)
            {
                case 0: // Initial BP
                    SetBreakPoints();
                    break;
                default:
                    SendMsg(output, "Breakpoint");
                    break;
            }
            return true;
        }

        public void DebuggerMode()
        {
            if (5000 < port && port < 8000 && Connected) // Already enabled
                return;
            setServer(host, 5000 + Pid);
            try { connectToServer(); } catch { SendMsg(null, "Disconnect"); SendMsg("Unable to enable debugger"); }
        }

        public void SetBreakPoints()
        {
            WriteWifiPatch();
            bpadd(FrameOffset, "code"); bpdis(2);
            bpadd(BlinkOffset, "code"); bpdis(3);
            bpadd(SyncOffset, "code"); bpdis(4);
            SendMsg("Breakpoint Set");
            resume();
        }

        public byte[] SingleThreadRead(uint addr, uint size = 4)
        {
            DataReady = false;
            Read(addr, size, Pid);
            int timeout = 10;
            do { Thread.Sleep(100); timeout--; } while (!DataReady && timeout > 0); // Try thread later
            if (timeout == 0) return null;
            return Data;
        }

        private void GetData(byte[] datBuf)
        {
            Data = (byte[])datBuf.Clone();
            DataReady = true;
        }
    }
}
