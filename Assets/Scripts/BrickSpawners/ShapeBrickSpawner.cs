using System.Collections.Generic;
using Controllers;
using Shapes;
using UnityEngine;

namespace BrickSpawners
{
	class ShapeBrickSpawner : MonoBehaviour, ISpawner
	{
		[SerializeField]
		private GameObject brickPrefab;
		[SerializeField]
		private Shape shape;
		[SerializeField]
		private BoxCollider2D boxCollider;

		private readonly List<GameObject> bricks = new List<GameObject>();
		private Vector2 brickSize;
		private Vector3 bottomLeftBrick = new Vector3(7f, 4f, 0f);
		private Vector3 topRightBrick = new Vector3(13f, 8f, 0f);

		public void SpawnBricksSet()
		{
			brickSize = boxCollider.size;
			var isPlacing = shape.GetPlacingArray();

			for (int i = 0; topRightBrick.y >= bottomLeftBrick.y + i * brickSize.y; i++)
			{
				for (int j = 0; topRightBrick.x >= bottomLeftBrick.x + j * brickSize.x; j++)
				{
					if (!isPlacing[i, j])
					{
						continue;
					}
					var horizontal = bottomLeftBrick.x + j * brickSize.x;
					var vertical = bottomLeftBrick.y + i * brickSize.y;

					var brickPosition = new Vector3(horizontal, vertical, 0f);
					var currentBrick = Instantiate(brickPrefab, brickPosition, Quaternion.identity);
					bricks.Add(currentBrick);

					currentBrick.GetComponent<BrickController>().SetSprite();
				}
			}
		}

		public List<GameObject> GetBricksSet()
		{
			return bricks;
		}
	}
}