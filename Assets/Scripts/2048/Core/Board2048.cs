using System.Collections.Generic;
using UnityEngine;

namespace _2048.Core
{
    public class Board2048
    {
        private readonly List<Node2048> _nodesList = new List<Node2048>();
        private readonly Dictionary<Vector2Int, Node2048> _nodeGrid = new Dictionary<Vector2Int, Node2048>();
        
        private readonly uint _columns;
        private readonly uint _rows;

        public Board2048(uint columns, uint rows)
        {
            _columns = columns;
            _rows = rows;
        }
        
        private void InstantiateBoard()
        {
            _nodeGrid.Clear();
            _nodesList.Clear();
            
            for (var i = 0; i < _columns; i++)
            {
                for (var j = 0; j < _rows; j++)
                {
                    
                }
            }
        }
    
        private void InstantiateNode(uint x, uint y)
        {
            
        }

        public void Move(Node2048 from, Node2048 to)
        {
            
        }
    }
}
