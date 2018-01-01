using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Bow : MonoBehaviour 
{
	// Variaveis privadas
	private Animation anim;
	private AudioSource audioSource;
	private float initPosX; // Posicao inicial em X da Flecha
	private bool toArm = false; // Flag para armar o arco
	private bool armArrow = false; // Flag para animar a flecha

	// Variaveis publicas
	public GameObject arrow;   
	public AudioClip armSound; 
	public AudioClip shootSound;

	// Use this for initialization
	void Start () 
	{
		anim = GetComponent<Animation> ();
		audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (GvrController.TouchDown || Input.GetMouseButtonDown (0)) 
		{
			TriggerPress ();
		}

		if (armArrow) 
		{
			if (arrow.transform.localPosition.x > -0.166f) 
			{
				arrow.transform.localPosition = new Vector3 (
					arrow.transform.localPosition.x - (Time.deltaTime) / 1.09f,
					arrow.transform.localPosition.y,
					arrow.transform.localPosition.z
				);
			} 
			else 
			{
				armArrow = false;
			}
		}
	}

	// Disparando...
	public void TriggerPress()
	{
		if (!toArm) {
			initPosX = arrow.transform.localPosition.x;
			EngageArchery ();
			armArrow = true;
		} 
		else 
		{
			DisengageArchery ();
		}
	}

	// Armando o Arco com a flecha
	void EngageArchery()
	{
		anim.Play ("Arm");
		if (anim.IsPlaying ("Arm")) 
		{
			audioSource.clip = armSound;
			audioSource.Play ();

			toArm = true;
		}
	}

	// Desarmando o Arco
	void DisengageArchery()
	{
		anim.Play ("Shoot");

		if (anim.IsPlaying ("Shoot")) 
		{
			audioSource.clip = shootSound;
			audioSource.Play ();

			toArm = false;
		}

		// Mecanismo de disparo
		// Para cada disparo será criada um flecha

		// Instanciar novas flechas
		GameObject newArrow = Instantiate(arrow);
		newArrow.transform.position = arrow.transform.position;
		newArrow.transform.rotation = arrow.transform.rotation;
		// Inserindo Rigbody dinamicamente
		newArrow.AddComponent<Rigidbody> ();
		newArrow.GetComponent<Rigidbody> ().AddForce (newArrow.transform.up * -5000);
		// Inserindo Collider dinamicamente
		newArrow.AddComponent<CapsuleCollider>();

		// retornando a flecha original para sua posição inicial
		arrow.transform.localPosition = new Vector3 (
			initPosX,
			arrow.transform.localPosition.y,
			arrow.transform.localPosition.z
		);
	}
}
