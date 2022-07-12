using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _2048.Core
{
    public class Board2048
    {
        public readonly Dictionary<Vector2Int, Node2048> NodeGrid = new Dictionary<Vector2Int, Node2048>();

        private readonly Vector2Int _boardBounds;

        public Board2048(Vector2Int boardBounds)
        {
            if (_boardBounds.x < 0 || _boardBounds.y < 0) 
                throw new Exception("Board bounds values can't be less than zero");
            
            _boardBounds = boardBounds;
            InstantiateBoard();
        }
        
        private void InstantiateBoard()
        {
            NodeGrid.Clear();
            InstantiateNode((uint)Random.Range(0, _boardBounds.x), (uint)Random.Range(0, _boardBounds.y));
            InstantiateNode((uint)Random.Range(0, _boardBounds.x), (uint)Random.Range(0, _boardBounds.y));
            for (var column = 0; column < _boardBounds.x; column++)
            {
                for (var row = 0; row < _boardBounds.y; row++)
                {
                    
                }
            }
        }
    
        private Node2048 InstantiateNode(uint x, uint y)
        {
            //NodeGrid.Where(x => x.Key == new Vector2Int((int)x,y));
            var position = new Vector2Int((int) x, (int) y);
            var node = new Node2048(position, 2);
            
            NodeGrid.Add(position, node);
            
            return node;
        }

        private void MoveNode(ref Node2048 fromNode, Node2048 toNode)
        {
            
        }
        
        public bool Combine(Node2048 fromNode, Node2048 toNode, out Node2048 newNode)
        {
            if (fromNode.Value == toNode.Value)
            {
                NodeGrid.Remove(toNode.Point);
                NodeGrid.Remove(fromNode.Point);
                
                newNode = new Node2048(toNode.Point, fromNode.Value + toNode.Value);
                
                NodeGrid.Add(newNode.Point, newNode);
            }

            newNode = null;
            return false;
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

        public bool CheckForGameOver()
        {
            bool isGameOver = true;
            foreach (var node in NodeGrid)
            {
                
            }

            return isGameOver;
        }
        
        public enum Direction { Top, Right, Bottom, Left }
    }
}
