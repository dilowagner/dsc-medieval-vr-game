using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Arrow : MonoBehaviour 
{
	private AudioSource audioSource;
	public AudioClip impactArrow;

	// Use this for initialization
	void Start () 
	{
		audioSource = GetComponent<AudioSource> ();	
	}
	
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag != "Arrow") 
		{
			audioSource.clip = impactArrow;
			audioSource.Play ();

			Destroy (GetComponent<Rigidbody>());
			Destroy (GetComponent<CapsuleCollider>());
		}
	}
}
