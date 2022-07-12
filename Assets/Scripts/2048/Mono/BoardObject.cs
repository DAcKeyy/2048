using System;
using _2048.Core;
using Miscellaneous.Extensions.Variables;
using UnityEngine;
using UnityEngine.UI;

namespace _2048.Mono
{
	public class BoardObject : MonoBehaviour
	{
		[SerializeField] private Vector2UInt _boardBounds;
		//TODO Сетка точек для твинов
		private Board2048 _boardData;
		
		private void Start()
		{
			CreateBoard();  
		}

		private void CreateBoard()
		{
			_boardData = new Board2048(_boardBounds);
			_boardData.GameOver += () => Debug.Log("Ты проебал");
			
		}

		public void Move(Slider.Direction direction)
		{
			switch (direction)
			{
				case Slider.Direction.LeftToRight:
					_boardData.Move(Board2048.Direction.Right);
					break;
				case Slider.Direction.RightToLeft:
					_boardData.Move(Board2048.Direction.Left);
					break;
				case Slider.Direction.BottomToTop:
					_boardData.Move(Board2048.Direction.Top);
					break;
				case Slider.Direction.TopToBottom:
					_boardData.Move(Board2048.Direction.Bottom);
					break;
			}
		}
	}
}