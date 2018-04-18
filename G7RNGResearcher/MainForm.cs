using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace G7RNGResearcher
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ntrclient = new NtrClient();
            ntrclient.Connect += OnConnected;
            ntrclient.Message += OnMsgArrival;
            IP.Text = Properties.Settings.Default.IP;
            ntrclient.setServer(IP.Text, 8000);
            B_Connect_Click(null, null);
        }
        private static NtrClient ntrclient;
        private static List<Model> ModelStatus = new List<Model>();

        private void NTR_Timer_Tick(object sender, EventArgs e)
        {
            try { ntrclient.sendHeartbeatPacket(); } catch { }
        }

        private void OnConnected(object sender, EventArgs e)
        {
            if (ntrclient.port == 8000)
            {
                Log.Items.Add("Console Connected");
                Properties.Settings.Default.IP = IP.Text;
                Properties.Settings.Default.Save();
                BP.Enabled =
                B_Connect.Enabled = false;
                B_Disconnect.Enabled = true;
                NTR_Timer.Enabled = true;
                ntrclient.listprocess();
            }
        }

        private void OnDisconnected(bool Success = true)
        {
            Log.Items.Add(Success ? "Disconnected" : "No Connection");
            NTR_Timer.Enabled = false;
            BP.Enabled =
            B_Connect.Enabled = true;
            B_Disconnect.Enabled = false;
        }

        private int ModelIndex;
        private int lastModelNumber;
        private int Time;
        private uint[] SkipBreakpoints =
        {
            0x421ECC, 0x421ED0, 0x421F3C, 0x421F40, 0x40F42C, 0x40F49C,
            0x72F7D4, 0x72F86C,
        };
        private void OnMsgArrival(object sender, NtrClient.InfoEventArgs e)
        {
            Invoke(new Action(() =>
            {
                switch (e.info)
                {
                    case "Breakpoint":
                        uint[] output = (uint[])e.data;
                        if (output[0] == 2 && SkipBreakpoints.Contains(output[1])) // RNG
                        {
                            switch (output[1])
                            {
                                case 0x72F7D4:
                                case 0x72F86C:
                                    Log.Items.Add("Fidget");
                                    break;
                            }
                        }
                        else if (output[0] == 6) // PKMCore
                        {
                            uint Address = output[3];
                            var p = new PkRNG(ntrclient.SingleThreadRead(Address, PkRNG.size));
                            Log.Items.Add($"PKM:{Address:X7}");
                            if (p.Species > 0 || p.PIDReroll > 1 || p.PerfectIVsCount > 0)
                                Log.Items.AddRange(p.Report());
                        }
                        else if (output[0] == 3) // 1 Graphic Frame
                        {
                            if (ModelIndex == lastModelNumber)
                            {
                                Time++;
                                Removelastmodellog();
                            }
                            else
                            {
                                if (Time == -1)
                                {
                                    Log.Items.Add((ModelIndex - lastModelNumber).ToString() + "Model Passed");
                                    Time = 0;
                                }
                                else
                                    Time = 1;
                                lastModelNumber = ModelIndex;
                            }
                            if (ModelIndex > 0)
                                Log.Items.Add("ModelNumber:" + lastModelNumber.ToString() + "\t\t x " + Time.ToString());
                            UpdateModel();
                            UpdateDGV();
                            RemoveFlag();
                            ModelIndex = 0;
                        }
                        else if (output[0] == 4) // Blink
                        {
                            var a = ModelStatus.FirstOrDefault(m => m.address == output[2]);
                            if (a == null)
                            {
                                ModelStatus.Add(new Model
                                {
                                    Index = ModelIndex++,
                                    address = output[2],
                                });
                                // B_Sort_Click(null, null);
                            }
                            else
                                a.Index = ModelIndex++;
                        }
                        else // Other usage
                        {
                            if (ModelIndex > 0)
                            {
                                if (ModelIndex == lastModelNumber)
                                {
                                    Removelastmodellog();
                                    if (Time > -1)
                                        Log.Items.Add("ModelNumber:" + lastModelNumber.ToString() + "\t\t x " + (Time + 1).ToString());
                                    Time = -1;
                                }
                                else
                                    Log.Items.Add(ModelIndex.ToString() + "Model Passed");
                            }
                            Time = Math.Min(Time, 0);
                            switch (output[0])
                            {
                                case 2:
                                    Log.Items.Add("Address:" + output[1].ToString("X8") + " %" + output[4].ToString());
                                    break;
                                case 5:
                                    Log.Items.Add("Lead Ability Check");
                                    break;
                                case 7:
                                    if (ntrclient.ResearchOffset != null)
                                        Log.Items.Add("Custom");
                                    else
                                        Log.Items.Add("Dialog Box");
                                    break;
                                case 8:
                                    Log.Items.Add("Address:" + output[1].ToString("X8") + "&" + output[2].ToString("X8"));
                                    break;
                                default:
                                    Log.Items.Add("Unk bp Address:" + output[1].ToString("X8"));
                                    break;
                            }
                        }
                        ntrclient.resume();
                        break;
                    case "Disconnect":
                        B_Disconnect_Click(null, null);
                        return;
                    case null:
                        Log.Items.Add((string)e.data);
                        return;
                }
            }));
        }

        private void Removelastmodellog()
        {
            if (Log.Items.Count == 0)
                return;
            if (((string)Log.Items[Log.Items.Count - 1]).Contains("ModelNumber:"))
                Log.Items.RemoveAt(Log.Items.Count - 1);
        }

        private void UpdateModel()
        {
            foreach (var A in ModelStatus)
                A.Data = ntrclient.SingleThreadRead(A.address, Model.Size);
        }

        private void UpdateDGV()
        {
            DGV.DataSource = new BindingSource(ModelStatus.Select(t => t.Clone()).ToArray(), null);
            DGV.CurrentCell = null;
        }

        private void RemoveFlag()
        {
            foreach (var A in ModelStatus)
                A.Index = -1;
        }

        private void B_Connect_Click(object sender, EventArgs e)
        {
            ntrclient.setServer(IP.Text, 8000);
            try
            {
                uint A = Convert.ToUInt32(BP.Text, 16);
                if (A > 0)
                    ntrclient.ResearchOffset = A;
                else
                    ntrclient.ResearchOffset = null;
            }
            catch
            {
                ntrclient.ResearchOffset = null;
            }
            try
            {
                ntrclient.connectToServer();
            }
            catch
            {
                OnDisconnected(false);
            }
        }

        private void B_Disconnect_Click(object sender, EventArgs e)
        {
            ntrclient.disconnect();
            OnDisconnected();
        }

        private void B_Clear_Click(object sender, EventArgs e)
        {
            Log.Items.Clear();
            ModelStatus.Clear();
            ModelIndex = lastModelNumber = Time = 0;
        }

        private void B_Resume_Click(object sender, EventArgs e)
        {
            try { ntrclient.resume(); } catch { };
        }

        private void B_Sort_Click(object sender, EventArgs e)
        {
            ModelStatus = ModelStatus.OrderBy(t => t.address).ToList();
            if (sender == B_Sort)
                UpdateDGV();
        }

        private void BP2_CheckedChanged(object sender, EventArgs e)
        {
            if (BP2.Checked)
                ntrclient.Enable(2);
            else
                ntrclient.Disable(2);
        }

        private void BP3_CheckedChanged(object sender, EventArgs e)
        {
            if (BP3.Checked)
                ntrclient.Enable(3, 4);
            else
                ntrclient.Disable(3, 4);
        }

        private void BP5_CheckedChanged(object sender, EventArgs e)
        {
            if (BP5.Checked)
                ntrclient.Enable(5);
            else
                ntrclient.Disable(5);
        }

        private void BP6_CheckedChanged(object sender, EventArgs e)
        {
            if (BP6.Checked)
                ntrclient.Enable(6);
            else
                ntrclient.Disable(6);
        }

        private void BP7_CheckedChanged(object sender, EventArgs e)
        {
            if (BP7.Checked)
                ntrclient.Enable(7);
            else
                ntrclient.Disable(7);
        }

        private void BP8_CheckedChanged(object sender, EventArgs e)
        {
            if (BP8.Checked)
                ntrclient.Enable(8);
            else
                ntrclient.Disable(8);
        }

        private void B_Disable_Click(object sender, EventArgs e)
        {
            BP2.Checked = BP3.Checked = BP5.Checked = BP6.Checked = BP7.Checked = BP8.Checked = false;
        }
    }
}
