using System.Collections;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
	public void TimeToDestroy()
	{
		StartCoroutine (DestroyBall());	
	}

	// Destruir a bola após um tempo
	IEnumerator DestroyBall()
	{
		yield return new WaitForSeconds (7);
		Destroy (this.gameObject);
	}
}
