using System;

namespace Miscellaneous.Extensions.Variables
{
    [Serializable]
    public struct MinMaxUInt
    {
        public uint min;
        public uint max;

        public MinMaxUInt(uint min, uint max)
        {
            this.min = min;
            this.max = max;
        }
    }
}