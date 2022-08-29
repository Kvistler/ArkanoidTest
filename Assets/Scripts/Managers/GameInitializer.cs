using Controllers;
using BrickSpawners;
using UnityEngine;

namespace Managers
{
	public class GameInitializer : MonoBehaviour
	{
		[SerializeField]
		private PlatformController platformPrefab;
		[SerializeField]
		private BallController ballPrefab;
		public ISpawner BrickSpawner { get; private set; }

		private BallController ball;
		private bool isStarted;

		private void Awake()
		{
			var platformInitialPosition = new Vector2(10f, 0.6f);
			var platform = Instantiate(platformPrefab, platformInitialPosition, Quaternion.identity);
			platform.SetSprite();
		
			ball = Instantiate(ballPrefab, platform.gameObject.transform);

			BrickSpawner = GetComponent<ISpawner>();
			BrickSpawner.SpawnBricksSet();

			Cursor.visible = false;
		}

		private void Update()
		{
			if (!isStarted)
			{
				WaitForStartingClick();
			}
		}

		private void WaitForStartingClick()
		{
			if (Input.GetMouseButtonDown(0))
			{
				ball.StartMovement();
				isStarted = true;
			}
		}
	}
}
