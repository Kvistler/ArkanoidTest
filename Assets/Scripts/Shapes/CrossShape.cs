using UnityEngine;

namespace Shapes
{
	[CreateAssetMenu(fileName = "CrossShape", menuName = "Cross Shape")]
	class CrossShape : Shape
	{
		public override bool[,] GetPlacingArray()
		{
			var placeBrick = new bool[10, 10];
			for (int i = 0; i < placeBrick.GetLength(0); i++)
			{
				placeBrick[i, i] = true;
				placeBrick[i, placeBrick.GetLength(1) - i - 1] = true;
			}
			return placeBrick;
		}
	}
}