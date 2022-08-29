using UnityEngine;

namespace Controllers
{
	public class BrickController : MonoBehaviour
	{
		[SerializeField]
		private float destroyDelay = 0.05f;
		[SerializeField]
		private SpriteRenderer spriteRenderer;
		[SerializeField]
		private Sprite[] sprites;

		public void SetSprite()
		{
			var index = Random.Range(0, sprites.Length);
			spriteRenderer.sprite = sprites[index];
		}

		public void Destroy()
		{
			Destroy(gameObject, destroyDelay);
		}
	}
}
