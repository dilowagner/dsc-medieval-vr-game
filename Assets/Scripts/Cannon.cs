using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Cannon : MonoBehaviour 
{
	// Variaveis publicas
	public GameObject cannonBall;
	public GameObject cannon;
	public AudioClip shootSound;
	public bool isActived = true;

	// Variaveis privadas
	private AudioSource audioSource;
	private Vector3 cannonPositionInit;
	private Quaternion cannonRotationInit;
	private Vector3 positionInit;
	private Quaternion rotationInit;

	private TargetPlayer targetPlayer;
	private Quaternion rotationPlayer;

	void Start () 
	{
		audioSource = GetComponent<AudioSource> ();

		cannonPositionInit = cannon.transform.position;
		cannonRotationInit = cannon.transform.rotation;

		positionInit = transform.position;
		rotationInit = transform.rotation;

		targetPlayer = FindObjectOfType<TargetPlayer> ();
		rotationPlayer = targetPlayer.transform.rotation;
	}

	void Update () 
	{
		if (isActived) 
		{
			// Realizar a rotação

			// Pegar a rotação do player
			rotationPlayer = targetPlayer.transform.rotation;

			// Criando a variável de rotação do canhão todo
			var allCannonEuler = transform.rotation.eulerAngles;
			// Aplicando a rotação da cabeça do player ao canhão todo
			allCannonEuler.y = rotationPlayer.eulerAngles.y;
			transform.rotation = Quaternion.Euler (allCannonEuler);

			// Criando a variável de rotação do canhão
			var cannonPointerEuler = cannon.transform.rotation.eulerAngles;
			// Aplicando a rotação do player ao canhão
			cannonPointerEuler.x = rotationPlayer.eulerAngles.x;
			cannon.transform.rotation = Quaternion.Euler (cannonPointerEuler);

			if (GvrController.TouchDown || Input.GetMouseButtonDown (0)) 
			{
				// Dispara o som
				audioSource.clip = shootSound;
				audioSource.Play ();

				// Instancia bolas de canhão
				GameObject ball = Instantiate(cannonBall);
				// Aplicando rotação a bola de canhão
				ball.transform.position = cannonBall.transform.position;
				ball.AddComponent<CannonBall> ();

				// Adicionando componente RigidyBody
				ball.AddComponent<Rigidbody>();
				ball.GetComponent<Rigidbody> ().mass = 80;

				// Aplicar força de disparo
				ball.GetComponent<Rigidbody>().AddForce(cannon.transform.forward * 200000);

				// Destroy a bola de canhão
				ball.GetComponent<CannonBall>().TimeToDestroy();
			}
		} 
		else 
		{
			// manter na posição inicial
			transform.rotation = rotationInit;
			transform.position = positionInit;

			cannon.transform.position = cannonPositionInit;
			cannon.transform.rotation = cannonRotationInit;
		}
	}
}
