using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	[RequireComponent(typeof(AudioSource))]
	public class TerrainMoveMechanism : MonoBehaviour
	{
		public GameObject quad; // Quadrado do Piso
		public int lengthX = 70; // Tamanho do piso em X
		public int lengthZ = 70; // Tamanho do piso em Z

		public float offSetX = 0.5f; // Ajustes de distância do centro dos quadrados em relação ao terreno
		public float offSetZ = 0.5f;

		[Range(0.01f, 0.2f)] public float height = 0.1f; // altura do quadriculado em relação ao piso

		private Vector3 posInit; // Posição inicial do piso.

		// Use this for initialization
		public void Start()
		{
			// posição inicial do terreno
			posInit = new Vector3(
				transform.position.x,
				transform.position.y + height,
				transform.position.z
			);

			for (var x = 0; x < lengthX; x++)
			{
				for (var z = 0; z < lengthZ; z++)
				{
					var quadriculado = Instantiate(quad);
					quadriculado.name = "PlayerPosition";
					quadriculado.transform.tag = "AllowedPosition";

					quadriculado.transform.position = new Vector3(
						posInit.x + x + offSetX,
						posInit.y,
						posInit.z + z + offSetZ
					);

					quadriculado.transform.parent = transform;
				}
			}
		}
	}
}
