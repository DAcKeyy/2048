using _2048.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _2048.Mono
{
	public class NodeObject : MonoBehaviour
	{
		[SerializeField] private Image _nodeImage;
		[SerializeField] private TMP_Text _text;
		private Node2048 _nodeData;

		public void SetNewData(Node2048 newNodeData)
		{
			_nodeData = newNodeData;
			SetColor(_nodeData.Value);
			_nodeData.Moved += (Vector2 s) => Debug.Log("Двигаюсь");

		}

		private void SetColor(uint value)
		{
			Color color = new Color(1f, 0.42f, 0.42f);
			
			switch (value)
			{
				case 2:
					ColorUtility.TryParseHtmlString("#eee4da", out color);
					break;
				case 4:
					ColorUtility.TryParseHtmlString("#eee1c9", out color);
					break;
				case 8:
					ColorUtility.TryParseHtmlString("#f3b27a", out color);
					break;
				case 16:
					ColorUtility.TryParseHtmlString("#f69664", out color);
					break;
				case 32: 
					ColorUtility.TryParseHtmlString("#f77c5f", out color);
					break;
				case 64: 
					ColorUtility.TryParseHtmlString("#f75f3b", out color);
					break;
				case 128:
					ColorUtility.TryParseHtmlString("#edd073", out color);
					break;
				case 256:
					ColorUtility.TryParseHtmlString("#f9f6f2", out color);
					break;
				case 512:
					ColorUtility.TryParseHtmlString("#f9f6f2", out color);
					break;
				case 1024:
					ColorUtility.TryParseHtmlString("#f9f6f2", out color);
					break;
				case 2048:
					ColorUtility.TryParseHtmlString("#f9f6f2", out color);
					break;
				case 4096:
					ColorUtility.TryParseHtmlString("#f9f6f2", out color);
					break;
			}

			_nodeImage.color = color;
		}
	}
}