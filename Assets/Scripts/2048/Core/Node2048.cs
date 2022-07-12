using UnityEngine;

namespace _2048.Core
{
	public class Node2048
	{
		public uint? Value { get; private set; }
		public Vector2Int Point { get; private set; }

		public Node2048(Vector2Int position)
		{
			Point = position;
			Value = 2; //TODO Magic number
		}
	}
}
