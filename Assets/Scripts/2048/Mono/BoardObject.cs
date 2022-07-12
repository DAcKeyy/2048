using _2048.Core;
using UnityEngine;

namespace _2048.Mono
{
	public class BoardObject : MonoBehaviour
	{
		[SerializeField] private uint колонки;
		[SerializeField] private uint строки;
		
		private Board2048 _boardData;
		
		private void Start()
		{
			CreateBoard();  
		}

		private void CreateBoard()
		{
			_boardData = new Board2048(колонки, строки);
			
		}
	}
}