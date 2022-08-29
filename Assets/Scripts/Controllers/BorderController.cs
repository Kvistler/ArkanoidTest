using UnityEngine;

namespace Controllers
{
	public class BorderController : MonoBehaviour
	{
		[SerializeField]
		private EdgeCollider2D edgeCollider;
		[SerializeField]
		private Camera mainCamera;

		private void Start()
		{
			SetupBorders();
		}

		/// <summary>
		/// Sets collider's boundaries to screen resolution
		/// </summary>
		private void SetupBorders()
		{
			var borderPoints = new Vector2[4];

			var bottomLeft = mainCamera.ScreenToWorldPoint(Vector2.zero);
			var topLeft = mainCamera.ScreenToWorldPoint(new Vector2(0f, Screen.height));
			var topRight = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
			var bottomRight = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, 0f));

			borderPoints[0] = bottomLeft;
			borderPoints[1] = topLeft;
			borderPoints[2] = topRight;
			borderPoints[3] = bottomRight;

			edgeCollider.points = borderPoints;

			transform.position = Vector3.zero;
		}
	}
}
