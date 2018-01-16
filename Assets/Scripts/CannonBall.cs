using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
	public class CannonBall : MonoBehaviour
	{
		public void TimeToDestroy()
		{
			StartCoroutine(DestroyBall());
		}

		// Destruir a bola após um tempo
		private IEnumerator DestroyBall()
		{
			yield return new WaitForSeconds(7);
			Destroy(this.gameObject);
		}
	}
}
