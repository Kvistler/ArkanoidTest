using System.Collections.Generic;
using Controllers;
using TMPro;
using UnityEngine;

namespace Managers
{
	public class GameLogic : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI stateMessage;
		[SerializeField]
		private TextMeshProUGUI scoreMessage;
		[SerializeField] 
		private GameInitializer gameInitializer;

		private int scoreCount;
		private List<GameObject> existingBricks;

		private void Start()
		{
			existingBricks = gameInitializer.BrickSpawner.GetBricksSet();

			var ball = FindObjectOfType<BallController>();
			ball.OnBrickDestroyed += OnBrickDestroyed;
			ball.OnBallDown += OnLose;
		}

		private void OnWin()
		{
			stateMessage.text = "you win!";
		}

		private void OnLose()
		{
			stateMessage.text = "game over";
		}

		private void OnBrickDestroyed(GameObject brick)
		{
			AddPoint();
			
			existingBricks.Remove(brick);
			if (existingBricks.Count == 0)
			{
				OnWin();
			}
		}

		private void AddPoint()
		{
			scoreCount++;
			scoreMessage.text = scoreCount.ToString();
		}
	}
}
