using System;
using UnityEngine;

namespace Controllers
{
	public class BallController : MonoBehaviour
	{
		[SerializeField]
		private float speed = 6f;

		private const string BrickTag = "Brick";
		private const string PlatformTag = "Platform";
		private const string BorderTag = "Border";
		private Vector3 movementDirection;
		private BallState state;

		public event Action<GameObject> OnBrickDestroyed;
		public event Action OnBallDown;

		private void Awake()
		{
			state = BallState.PreStart;
			SetMovementDirection();
		}

		private void SetMovementDirection()
		{
			var movementLean = UnityEngine.Random.Range(-1f, 1f);
			movementDirection = new Vector3(movementLean, 1f, 0f);
			movementDirection = movementDirection.normalized;
		}

		private void Update()
		{
			if (state != BallState.InGame)
			{
				return;
			}
			
			CheckIfOnBottom();
			Move();
		}

		private void CheckIfOnBottom()
		{
			if (transform.position.y <= 0f)
			{
				OnBallDown?.Invoke();
				Destroy(gameObject);
			}
		}

		private void Move()
		{
			transform.position += movementDirection * speed * Time.deltaTime;
		}

		private void OnCollisionEnter2D(Collision2D collision)
		{
			var collisionObject = collision.gameObject;
			if (collisionObject.CompareTag(PlatformTag) ||
			    collisionObject.CompareTag(BorderTag) ||
			    collisionObject.CompareTag(BrickTag))
			{
				Bounce(collision.contacts[0].normal);
			}
			if (collisionObject.CompareTag(BrickTag))
			{
				collisionObject.GetComponent<BrickController>().Destroy();
				OnBrickDestroyed?.Invoke(collisionObject);
			}
		}

		private void Bounce(Vector2 normal)
		{
			movementDirection = Vector3.Reflect(movementDirection, normal).normalized;
			Move();
		}

		public void StartMovement()
		{
			state = BallState.InGame;
			transform.parent = null;
		}
	}
}
