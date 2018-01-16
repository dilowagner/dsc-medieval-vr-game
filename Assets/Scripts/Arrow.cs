using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	[RequireComponent(typeof(AudioSource))]
	public class Arrow : MonoBehaviour
	{
		private AudioSource _audioSource;
		public AudioClip ImpactArrow;

		// Use this for initialization
		public void Start()
		{
			_audioSource = GetComponent<AudioSource>();
		}

		public void OnCollisionEnter(Collision collision)
		{
			if (collision.gameObject.tag != "Arrow")
			{
				_audioSource.clip = ImpactArrow;
				_audioSource.Play();

				Destroy(GetComponent<Rigidbody>());
				Destroy(GetComponent<CapsuleCollider>());
			}
		}
	}
}
