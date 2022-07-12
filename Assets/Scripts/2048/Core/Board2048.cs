#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using Miscellaneous.Extensions.Variables;
using Random = UnityEngine.Random;

namespace _2048.Core
{
    public class Board2048
    {
        public Dictionary<Vector2UInt, Node2048> NodeGrid { get; private set; }
        public Vector2UInt BoardBounds { get; private set; }
        
        public Action<Node2048> NodeAdded = delegate(Node2048 node2048) {  };
        public Action<Node2048> NodeRemoved = delegate(Node2048 node2048) {  };

        public Board2048(Vector2UInt boardBounds)
        {
            if (boardBounds.x == 0 || boardBounds.y == 0) 
                throw new Exception("Board bounds too small");
            
            BoardBounds = boardBounds;
            NodeGrid = new Dictionary<Vector2UInt, Node2048>();
            InstantiateBoard();
        }
        
        private void InstantiateBoard()
        {
            NodeGrid.Clear();
            InitStartNodes((uint)Random.Range(1,3));
            
            for (var column = 0; column < BoardBounds.x; column++)
            {
                for (var row = 0; row < BoardBounds.y; row++)
                {
                    
                }
            }
        }
    
        private bool InstantiateNode(uint x, uint y, out Node2048? node)
        {
            node = null;

            if (x >= BoardBounds.x) return false;
            if (y >= BoardBounds.y) return false;
                
            var existNode = NodeGrid.FirstOrDefault(gridElem => gridElem.Key == new Vector2UInt(x,y));

            if (existNode.Key == new Vector2UInt(x, y))
            {
                var position = new Vector2UInt(x, y);
                node = new Node2048(position, (uint)Random.Range(2, 4));
                AddNode(node);
                return true;
            }
            else return false;
        }

        private void MoveNode(ref Node2048 fromNode, Vector2UInt position)
        {
            
        }
        
        public bool Combine(Node2048 fromNode, Node2048 toNode, out Node2048? newNode)
        {
            if (fromNode.Value == toNode.Value)
            {
                RemoveNode(toNode);
                RemoveNode(fromNode);
                
                newNode = new Node2048(toNode.Position, fromNode.Value + toNode.Value);
                
                AddNode(newNode);
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

        private void AddNode(Node2048 newNode)
        {
            NodeGrid.Add(newNode.Position, newNode);
            NodeAdded(newNode);
        }
        
        private void RemoveNode(Node2048 node)
        {
            NodeGrid.Remove(node.Position);
            NodeRemoved(node);
        }

        private void InitStartNodes(uint amount)
        {
            for (int i = 0; i < amount; i++)
            {
                if (true == InstantiateNode(
                        (uint) Random.Range(0, BoardBounds.x),
                        (uint) Random.Range(0, BoardBounds.y),
                        out Node2048? node))
                {
                    NodeGrid.Add(node.Position, node);
                }
                else
                {
                    i--;
                }
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
