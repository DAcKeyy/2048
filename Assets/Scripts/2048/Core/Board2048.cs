using System;
using System.Collections.Generic;
using UnityEngine;

namespace _2048.Core
{
    public class Board2048
    {
        public readonly Dictionary<Vector2Int, Node2048> NodeGrid = new Dictionary<Vector2Int, Node2048>();

        private readonly uint _columns;
        private readonly uint _rows;

        public Board2048(uint columns, uint rows)
        {
            _columns = columns;
            _rows = rows;

            InstantiateBoard();
        }
        
        private void InstantiateBoard()
        {
            NodeGrid.Clear();

            for (var i = 0; i < _columns; i++)
            {
                for (var j = 0; j < _rows; j++)
                {
                    
                }
            }
        }
    
        public Node2048 InstantiateNode(uint x, uint y)
        {
            var position = new Vector2Int((int) x, (int) y);
            var node = new Node2048(position);
            
            NodeGrid.Add(position, node);
            
            return node;
        }

        private void MoveNode(ref Node2048 fromNode, Node2048 toNode)
        {
            
        }
        
        public void Move(Direction direction)
        {
            if (direction == Direction.Top)
            {
                
            }
            
            if (direction == Direction.Right)
            {
                
            }
            
            if (direction == Direction.Bottom)
            {
                
            }
            
            if (direction == Direction.Left)
            {
                
            }
        }

        public enum Direction { Top, Right, Bottom, Left }
    }
}
