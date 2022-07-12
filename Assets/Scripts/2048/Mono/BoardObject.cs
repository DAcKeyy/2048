using _2048.Core;
using Miscellaneous.Extensions.Variables;
using UnityEngine;

namespace _2048.Mono
{
	public class BoardObject : MonoBehaviour
	{
		[SerializeField] private Vector2UInt _boardBounds;
		
		private Board2048 _boardData;
		
		private void Start()
		{
			CreateBoard();  
		}

		private void CreateBoard()
		{
			_boardData = new Board2048(_boardBounds);
			
		}
	}
}