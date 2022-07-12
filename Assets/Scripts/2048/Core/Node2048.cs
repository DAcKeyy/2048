using System.Collections.Generic;
using System.Linq;
using Miscellaneous.Extensions.Variables;
using UnityEngine;

namespace _2048.Core
{
	public class Node2048
	{
		public uint Value { get; private set; }
		public Vector2UInt Position { get; private set; }
		
		private Dictionary<Board2048.Direction, Node2048> _possibleCombinations = new Dictionary<Board2048.Direction, Node2048>(4);

		public Node2048(Vector2UInt position, uint value)
		{
			Position = position;
			Value = value;
		}

		public void CheckPossibleCombinations(ref Dictionary<Vector2UInt, Node2048> nodesGrid)
		{
			foreach (var node in nodesGrid
		         .Where(node => node.Key.Equals(Position))
		         .Where(node => node.Value.Equals(this)))
			{
				
			}
		}
	}
}
