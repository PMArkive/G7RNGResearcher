using System;
using System.Linq;

namespace G7RNGResearcher
{
    public class PkRNG
    {
        public PkRNG(byte[] d)
        {
            data = d?.Length == size ? (byte[])d.Clone() : new byte[size];
        }

        private byte[] data;
        public const int size = 56;

        public ulong EC => BitConverter.ToUInt64(data, 0);
        public ulong PID => BitConverter.ToUInt64(data, 8);
        public ulong TID => BitConverter.ToUInt64(data, 16);
        public ushort Species => BitConverter.ToUInt16(data, 24);
        public byte Forme => data[26];
        public ushort Level => BitConverter.ToUInt16(data, 28);
        public ushort Gender => BitConverter.ToUInt16(data, 30);
        public ushort Nature => BitConverter.ToUInt16(data, 32);
        public byte Ability => data[34];
        public byte PIDReroll => data[35];
        public ushort[] IVs => new[] { BitConverter.ToUInt16(data, 36), BitConverter.ToUInt16(data, 38), BitConverter.ToUInt16(data, 40), BitConverter.ToUInt16(data, 42), BitConverter.ToUInt16(data, 44), BitConverter.ToUInt16(data, 46), };
        public uint Friendship => BitConverter.ToUInt32(data, 48);
        public byte PerfectIVsCount => data[52];

        public string[] Report()
        {
            string[] PIDType = { "Anti-Shiny", "Shiny", "Random" };
            string[] GenderType = { "Random", "Male", "Female", "Genderless" };
            string[] AbilityType = { "Random", "1", "2", "H" };
            var pidstr = (uint)PID == uint.MaxValue ? PIDType[(PID >> 32) - 1] : PID.ToString("X");
            var naturestr = Nature == ushort.MaxValue ? "Random" : Nature.ToString();
            var lines = new string[3];
            lines[0] = "EC:" + (EC == ulong.MaxValue ? "Random" : EC.ToString("X"));
            lines[0] += $"\tPID: {pidstr}\tRollcount:{PIDReroll}\t";
            lines[0] += "TID:" + (TID == ulong.MaxValue ? "Random" : (TID % 1000000).ToString("D6"));
            lines[1] = $"SpecForm:{Species} - {Forme}  \tLv:{Level}\tN:{naturestr}\tA:{AbilityType[(byte)(Ability + 1)]}\tG:{GenderType[(byte)(Gender + 1)]}" + Environment.NewLine;
            lines[2] = $"Flawless count: {PerfectIVsCount}\tIVs:{string.Join(",", IVs.Select(iv => iv == 0xFFFF ? "R" : iv.ToString()))}";
            return lines;
        }
    }
}
