using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	[RequireComponent(typeof(AudioSource))]
	public class RVPlayer : MonoBehaviour
	{
		// Variaveis publicas
		public Camera cameraRayCasting; // Camera para apontamento da posição e de objetos 3D
		public float speed = 0.7f; // Velocidade do player
		public int distanceToMove = 10; // Sinalização da posição máxima que o player pode caminhar
		public GameObject arrowToMove; // a seta de apontamento
		public AudioClip clickSound; // Quando o botão do óculos for clicado.
		public GameObject bowAndArrow;

		// Variaveis privadas
		private AudioSource audioSource; // Componente para dara play no audio
		private RaycastHit hit;
		private Vector3 startPoint; // posição atual do player
		private Vector3 endPoint; // ponto de seleção
		private float startTime; // Tempo em que o usuário clicou
		private float journeyLength; // Distância entre RVPlayer e ponto selecionado
		private bool flagStop = false; // flag de parada de movimentação
		public bool moviment = true;

		// Use this for initialization
		void Start()
		{
			audioSource = GetComponent<AudioSource>();
		}

		// Update is called once per frame
		public void Update()
		{
			if (moviment)
			{
				// Raycasting de apontamento, selecionar os gameObjects da cena
				Ray ray = cameraRayCasting.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

				// Obter o objeto apontado
				if (Physics.Raycast(ray, out hit, distanceToMove))
				{
					//Debug.Log (hit.transform.position + " : " + hit.transform.name);	
					float scaleArrow = Vector3.Distance(hit.transform.position, transform.position) / 13000;
					arrowToMove.transform.localScale = new Vector3(scaleArrow, scaleArrow, scaleArrow);
					arrowToMove.transform.position = hit.transform.position;
				}

				// mecanismo de movimentação
				if (GvrController.TouchDown || Input.GetMouseButtonDown(0))
				{
					if (Physics.Raycast(ray, out hit, distanceToMove))
					{
						if (hit.transform.tag == "AllowedPosition")
						{
							audioSource.clip = clickSound;
							audioSource.Play();

							startPoint = transform.position;
							endPoint = hit.transform.position;

							startTime = Time.time;
							journeyLength = Vector3.Distance(startPoint, endPoint);

							flagStop = true;
						}
					}
				}

				if (flagStop)
				{
					float distCoverd = (Time.time - startTime) * speed;
					float fracJourney = distCoverd / journeyLength;
					Vector3 move = Vector3.Lerp(startPoint, endPoint, fracJourney);

					transform.position = move;

					// Se player chegou a posição final
					if (transform.position == endPoint)
					{
						flagStop = false;
					}
				}
			}
		}

		public void SetMoviment(bool value)
		{
			moviment = value;
			if (moviment)
			{
				var cannons = FindObjectsOfType<Cannon>();
				foreach (Cannon cannon in cannons)
				{
					cannon.isActived = false;
				}

				arrowToMove.SetActive(true);
				bowAndArrow.SetActive(true);
			}
		}
	}
}
