using System.Collections.Generic;
using System.Linq;
using Miscellaneous.Extensions.Variables;

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

		public void CheckPossibleCombinations(ref Board2048 board)
		{
			var node = board.NodeGrid.FirstOrDefault(node => node.Value.Equals(this)).Value;
			
			//top
			for (var y = node.Position.y;
			     y < board.BoardBounds.x; 
			     y++)
			{
				var possibleNode = board.NodeGrid.FirstOrDefault(nodePos => 
					nodePos.Key == new Vector2UInt(node.Position.x, y)).Value;
				
				if (possibleNode == null) continue;
				
				if(possibleNode.Value == node.Value) _possibleCombinations.Add(Board2048.Direction.Top, possibleNode);
			}
			
			//right
			for (var x = node.Position.x;
			     x < board.BoardBounds.x; 
			     x++)
			{
				var possibleNode = board.NodeGrid.FirstOrDefault(nodePos => 
					nodePos.Key == new Vector2UInt(x, node.Position.y)).Value;
				
				if (possibleNode == null) continue;
				
				if(possibleNode.Value == node.Value) _possibleCombinations.Add(Board2048.Direction.Right, possibleNode);
			}
			
			//bottom
			for (var y = node.Position.y;
			     y > 0;
			     y--)
			{
				var possibleNode = board.NodeGrid.FirstOrDefault(nodePos => 
					nodePos.Key == new Vector2UInt(node.Position.x, y)).Value;
				
				if (possibleNode == null) continue;
				
				if(possibleNode.Value == node.Value) _possibleCombinations.Add(Board2048.Direction.Bottom, possibleNode);
			}
			
			//left
			for (var x = node.Position.x;
			     x > 0;
			     x--)
			{
				var possibleNode = board.NodeGrid.FirstOrDefault(nodePos => 
					nodePos.Key == new Vector2UInt(x, node.Position.y)).Value;
				
				if (possibleNode == null) continue;
				
				if (possibleNode.Value == node.Value) _possibleCombinations.Add(Board2048.Direction.Left, possibleNode);
			}
		}
	}
}
