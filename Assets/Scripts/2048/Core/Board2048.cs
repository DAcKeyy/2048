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
        public List<Node2048> NodeGrid { get; private set; }
        public Vector2UInt BoardBounds { get; private set; }
        
        public Action<Node2048> NodeAdded = delegate(Node2048 node2048) {  };
        public Action<Node2048> NodeRemoved = delegate(Node2048 node2048) {  };
        public Action GameOver = delegate() {  };

        public Board2048(Vector2UInt boardBounds)
        {
            if (boardBounds.x == 0 || boardBounds.y == 0) 
                throw new Exception("Board bounds too small");
            
            BoardBounds = boardBounds;
            NodeGrid = new List<Node2048>();
            
            NodeGrid.Clear();
            InitStartNodes((uint)Random.Range(1,3));
        }

        private bool InstantiateNode(uint x, uint y, out Node2048? node)
        {
            node = null;

            if (x >= BoardBounds.x) return false;
            if (y >= BoardBounds.y) return false;
                
            var existNode = NodeGrid.FirstOrDefault(gridElem => gridElem.Position == new Vector2UInt(x,y));

            if (existNode != null && existNode.Position == new Vector2UInt(x, y))
            {
                var position = new Vector2UInt(x, y);
                node = new Node2048(position, (uint)Random.Range(2, 4));
                AddNode(node);
                return true;
            }
            else return false;
        }

        private bool MoveNode(ref Node2048 fromNode, Vector2UInt newPosition)
        {
            var node = NodeGrid.First(nodePos => nodePos.Position == newPosition);
            if (node != null) return false;

            fromNode.Position = newPosition;
            return true;
        }
        
        public bool Combine(Node2048 fromNode, Node2048 toNode, out Node2048? newNode)
        {
            if (fromNode.Value == toNode.Value)
            {
                newNode = new Node2048(toNode.Position, fromNode.Value + toNode.Value);
                RemoveNode(toNode);
                RemoveNode(fromNode);
                AddNode(newNode);
            }

            newNode = null;
            return false;
        }
        
        public void Move(Direction direction)
        {
            foreach (var node in NodeGrid)
            {
                var cortage = node.PossibleCombinations.First(collection => collection.direction == direction);
                
                if(cortage.possibleNode == null) continue;
                
                Combine(node, cortage.possibleNode, out var newNode);
            }
            
            if (direction == Direction.Top)
            {
                for (uint x = BoardBounds.x - 1;
                     x > 0;
                     x--)
                for (uint y = BoardBounds.y - 1;
                     y > 0;
                     y--)
                {
                    var node = NodeGrid.First(nodePos => nodePos.Position == new Vector2UInt(x, y));
                    if(node == null) continue;
                    
                    Board2048 thisBoard = this;
                    if (true == node.GetNeighbour(Direction.Top, in thisBoard, out var neighbourNode))
                    {
                        MoveNode(ref node, new Vector2UInt(node.Position.x, neighbourNode.Position.y-1));
                    }
                    else
                    {
                        MoveNode(ref node, new Vector2UInt(node.Position.x, BoardBounds.y-1));
                    }
                }
            }
            
            if (direction == Direction.Right)
            {
                for (uint y = BoardBounds.y - 1;
                     y > 0;
                     y--)
                for (uint x = BoardBounds.x - 1;
                     x > 0;
                     x--)
                {
                    var node = NodeGrid.First(nodePos => nodePos.Position == new Vector2UInt(x, y));
                    if(node == null) continue;
                
                    Board2048 thisBoard = this;
                    if (true == node.GetNeighbour(Direction.Right, in thisBoard, out var neighbourNode))
                    {
                        MoveNode(ref node, new Vector2UInt(neighbourNode.Position.x-1, node.Position.y));
                    }
                    else
                    {
                        MoveNode(ref node, new Vector2UInt(BoardBounds.x - 1, node.Position.y));
                    }
                }
                
            }
            
            if (direction == Direction.Bottom)
            {
                for (uint x = 0;
                     x < BoardBounds.x - 1;
                     x++)
                for (uint y = 0;
                     y < BoardBounds.y - 1;
                     y++)
                {
                    var node = NodeGrid.First(nodePos => nodePos.Position == new Vector2UInt(x, y));
                    if(node == null) continue;
                    
                    Board2048 thisBoard = this;
                    if (true == node.GetNeighbour(Direction.Bottom, in thisBoard, out var neighbourNode))
                    {
                        MoveNode(ref node, new Vector2UInt(node.Position.x, neighbourNode.Position.y+1));
                    }
                    else
                    {
                        MoveNode(ref node, new Vector2UInt(node.Position.x, 0));
                    }
                }
            }
            
            if (direction == Direction.Left)
            {
                for (uint y = 0;
                     y < BoardBounds.y - 1;
                     y++)
                for (uint x = 0;
                     x < BoardBounds.x - 1;
                     x++)
                {
                    var node = NodeGrid.First(nodePos => nodePos.Position == new Vector2UInt(x, y));
                    if(node == null) continue;
                
                    Board2048 thisBoard = this;
                    if (true == node.GetNeighbour(Direction.Left, in thisBoard, out var neighbourNode))
                    {
                        MoveNode(ref node, new Vector2UInt(neighbourNode.Position.x+1, node.Position.y));
                    }
                    else
                    {
                        MoveNode(ref node, new Vector2UInt(0, node.Position.y));
                    }
                }
            }

            if (CheckForGameOver()) GameOver();
        }

        private void AddNode(Node2048 newNode)
        {
            NodeGrid.Add(newNode);
            NodeAdded(newNode);
        }
        
        private void RemoveNode(Node2048 node)
        {
            NodeGrid.Remove(node);
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
                    if (node != null) 
                        NodeGrid.Add(node);
                }
                else
                {
                    i--;
                }
            }
            
            CheckPossibleCombinations();
        }

        private void CheckPossibleCombinations()
        {
            Board2048 thisBoard = this;
            foreach (var node in NodeGrid)
            {
                node.CheckPossibleCombinations(in thisBoard);
            }
        }
        
        public bool CheckForGameOver()
        {
            bool isAbleToPlay = false;
            
            if (NodeGrid.Count == BoardBounds.x * BoardBounds.y)
            {
                Board2048 thisBoard = this;
                foreach (var node in NodeGrid)
                {
                    node.CheckPossibleCombinations(in thisBoard);
                    
                    foreach (var cortage in node.PossibleCombinations)
                    {
                        if (cortage.possibleNode != null)
                        {
                            isAbleToPlay = true;
                            break;
                        }
                    }
                    if(isAbleToPlay) break;
                }
            }
            return !isAbleToPlay;
        }
        
        public enum Direction { Top, Right, Bottom, Left }
    }
}
