using System.Collections.Generic;
using Controllers;
using UnityEngine;

namespace BrickSpawners
{
	public class DefaultBrickSpawner : MonoBehaviour, ISpawner
	{
		[SerializeField]
		private GameObject brickPrefab;
		[SerializeField]
		private Vector3 bottomLeftBrick = new Vector3(2f, 6f, 0f);
		[SerializeField]
		private Vector3 topRightBrick = new Vector3(18f, 8f, 0f);
		[SerializeField]
		private BoxCollider2D boxCollider;

		private readonly List<GameObject> bricks = new List<GameObject>();
		private Vector2 brickSize;

		public void SpawnBricksSet()
		{
			brickSize = boxCollider.size;
			for (int i = 0; topRightBrick.y >= bottomLeftBrick.y + i * brickSize.y; i++)
			{
				for (int j = 0; topRightBrick.x >= bottomLeftBrick.x + j * brickSize.x; j++)
				{
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
