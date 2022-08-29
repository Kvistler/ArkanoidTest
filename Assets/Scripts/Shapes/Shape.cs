using UnityEngine;

namespace Shapes
{
	abstract class Shape : ScriptableObject
	{
		abstract public bool[,] GetPlacingArray();
	}
}