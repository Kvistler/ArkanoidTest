using UnityEngine;

namespace Controllers
{
	public class PlatformController : MonoBehaviour
	{
		[SerializeField]
		private float defaultHeight = 0.6f;
		[SerializeField]
		private SpriteRenderer spriteRenderer;
		[SerializeField]
		private Sprite[] sprites;

		private Camera mainCamera;
		private float horizontalPosition = 10f;

		private void Start()
		{
			mainCamera = Camera.main;
		}

		private void Update()
		{
			FollowPlayer();
		}

		private void FollowPlayer()
		{
#if UNITY_ANDROID || UNITY_IOS
			TouchControl();
#else
			MouseControl();
#endif
			transform.position = new Vector3(horizontalPosition, defaultHeight, 0f);
		}

		private void TouchControl()
		{
			if (Input.touchCount > 0)
			{
				horizontalPosition = mainCamera.ScreenToWorldPoint(Input.touches[0].position).x;
			}
		}

		private void MouseControl()
		{
			horizontalPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition).x;
		}

		public void SetSprite()
		{
			var index = Random.Range(0, sprites.Length);
			spriteRenderer.sprite = sprites[index];
		}
	}
}
