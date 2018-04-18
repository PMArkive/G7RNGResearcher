using System.ComponentModel;

namespace G7RNGResearcher
{
    public class Model
    {
        public const uint Size = 0x100;

        public int Index { get; set; }
        public bool Active => Index >= 0;
        public uint address;
        public string Address => address.ToString("X8");

        public Model Clone() => new Model
        {
            Index = Index,
            address = address,
            data = data,
        };

        private byte[] data;
        [Browsable(false)]
        public byte[] Data { get => data; set => data = (byte[])value.Clone(); }

        public byte Eyes => data[0xDC];
        public byte State => data[0xDF];
        public byte Count => data[0xE1];
        public bool DoubleBlink => data[0xE4] == 1;
        public bool UseRNG => Active && !DoubleBlink && (State == 0 && Count < 2 || State == 5);
    }
}