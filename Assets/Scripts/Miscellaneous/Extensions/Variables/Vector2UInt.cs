using System;

namespace Miscellaneous.Extensions.Variables
{
	[Serializable]
	public struct Vector2UInt
	{
		public uint x;
		public uint y;

		public Vector2UInt(uint x, uint y)
		{
			this.x = x;
			this.y = y;
		}
		
		public static bool operator ==(Vector2UInt vector1, Vector2UInt vector2)
		{
			if (vector1.x != vector2.x) return false;
			return vector1.y == vector2.y;
		}

		public static bool operator !=(Vector2UInt counter1, Vector2UInt counter2)
		{
			return !(counter1 == counter2);
		}
	}
	
}