using System;

namespace Miscellaneous.Extensions.Variables
{
    [Serializable]
    public class MinMaxFloat
    {
        public float min;
        public float max;

        public MinMaxFloat(float min, float max)
        {
            this.min = min;
            this.max = max;
        }
    }
}