#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using Miscellaneous.Extensions.Variables;
using UnityEngine;

namespace _2048.Core
{
	public class Node2048
	{
		public uint Value { get; private set; }
		public Vector2UInt Position
		{
			get => Position;
			set
			{
				Moved(new Vector2(value.x, value.y));
				Position = value;
			}
		}
		public Action<Vector2> Moved = delegate {  };

		public List<(Board2048.Direction direction, Node2048? possibleNode)> PossibleCombinations { get; private set; }

		public Node2048(Vector2UInt position, uint value)
		{
			Position = position;
			Value = value;
			PossibleCombinations = new List<(Board2048.Direction direction, Node2048? possibleNode)>(4)
			{
				{(Board2048.Direction.Top, null)},
				{(Board2048.Direction.Right, null)},
				{(Board2048.Direction.Bottom, null)},
				{(Board2048.Direction.Left, null)}
			};
		}

		public void CheckPossibleCombinations(in Board2048 board)
		{
			var node = board.NodeGrid.First(node => node.Value == this.Value);
			var topCombination = PossibleCombinations.First(combination => combination.direction == Board2048.Direction.Top);
			var rightCombination = PossibleCombinations.First(combination => combination.direction == Board2048.Direction.Right);
			var bottomCombination = PossibleCombinations.First(combination => combination.direction == Board2048.Direction.Bottom);
			var leftCombination = PossibleCombinations.First(combination => combination.direction == Board2048.Direction.Left);
			
			//top
			if (node.Position.y == board.BoardBounds.y - 1) topCombination.possibleNode = null;
			for (var y = node.Position.y;
			     y < board.BoardBounds.y; 
			     y++)
			{
				var possibleNode = board.NodeGrid.First(nodePos => 
					nodePos.Position == new Vector2UInt(node.Position.x, y));
				
				if (possibleNode == null) continue;

				if (possibleNode.Value == node.Value) 
					topCombination.possibleNode = possibleNode;
				
				else topCombination.possibleNode = null;
				
				break;
			}
			
			//right
			if (node.Position.x == board.BoardBounds.x - 1) rightCombination.possibleNode = null;
			for (var x = node.Position.x;
			     x < board.BoardBounds.x; 
			     x++)
			{
				var possibleNode = board.NodeGrid.First(nodePos => 
					nodePos.Position == new Vector2UInt(x, node.Position.y));
				
				if (possibleNode == null) continue;

				if (possibleNode.Value == node.Value) 
					rightCombination.possibleNode = possibleNode;
				
				else rightCombination.possibleNode = null;
				
				break;
			}
			
			//bottom
			if (node.Position.y == 0) bottomCombination.possibleNode = null;
			for (var y = node.Position.y;
			     y > 0;
			     y--)
			{
				var possibleNode = board.NodeGrid.First(nodePos => 
					nodePos.Position == new Vector2UInt(node.Position.x, y));
				
				if (possibleNode == null) continue;
				
				if (possibleNode.Value == node.Value) 
					bottomCombination.possibleNode = possibleNode;
				
				else bottomCombination.possibleNode = null;
				
				break;
			}
			
			//left
			if (node.Position.x == 0) leftCombination.possibleNode = null;
			for (var x = node.Position.x;
			     x > 0;
			     x--)
			{
				var possibleNode = board.NodeGrid.First(nodePos => 
					nodePos.Position == new Vector2UInt(x, node.Position.y));
				
				if (possibleNode == null) continue;
				
				if (possibleNode.Value == node.Value) 
					leftCombination.possibleNode = possibleNode;
				
				else leftCombination.possibleNode = null;
				
				break;
			}
		}

		public bool GetNeighbour(Board2048.Direction direction, in Board2048 board, out Node2048? neighbourNode)
		{
			neighbourNode = null;
			bool isFounded = false;

			if (direction == Board2048.Direction.Top)
			{
				for (var y = this.Position.y;
				     y < board.BoardBounds.y; 
				     y++)
				{
					var possibleNeighbourNode = board.NodeGrid.First(nodePos => 
						nodePos.Position == new Vector2UInt(this.Position.x, y));
				
					if (possibleNeighbourNode == null) continue;
					else
					{
						neighbourNode = possibleNeighbourNode;
						break;
					}
				}
			}
			
			if (direction == Board2048.Direction.Right)
			{
				for (var x = this.Position.x;
				     x < board.BoardBounds.x; 
				     x++)
				{
					var possibleNeighbourNode = board.NodeGrid.First(nodePos => 
						nodePos.Position == new Vector2UInt(x, this.Position.y));
				
					if (possibleNeighbourNode == null) continue;
					else
					{
						neighbourNode = possibleNeighbourNode;
						break;
					}
				}
			}
			
			if (direction == Board2048.Direction.Bottom)
			{
				for (var y = this.Position.y;
				     y > 0;
				     y--)
				{
					var possibleNeighbourNode = board.NodeGrid.First(nodePos => 
						nodePos.Position == new Vector2UInt(this.Position.x, y));
				
					if (possibleNeighbourNode == null) continue;
					else
					{
						neighbourNode = possibleNeighbourNode;
						break;
					}
				}
			}
			
			if (direction == Board2048.Direction.Left)
			{
				for (var x = this.Position.x;
				     x > 0;
				     x--)
				{
					var possibleNeighbourNode = board.NodeGrid.First(nodePos => 
						nodePos.Position == new Vector2UInt(x, this.Position.y));
				
					if (possibleNeighbourNode == null) continue;
					else
					{
						neighbourNode = possibleNeighbourNode;
						break;
					}
				}
			}

			return isFounded;
		}
	}
}
