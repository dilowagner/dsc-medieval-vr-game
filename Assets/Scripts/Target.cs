using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class Target : MonoBehaviour
	{
		// Argolas do Alvo
		public GameObject level1;
		public GameObject level2;
		public GameObject level3;

		// Particulas quando a flecha atingir o alvo
		public ParticleSystem particleDust;

		public ParticleSystem particle10Points;
		public ParticleSystem particle50Points;
		public ParticleSystem particle100Points;

		public enum TargetEnum
		{
			None,
			Level1,
			Level2,
			Level3
		}

		// Use this for initialization
		void Start()
		{
			// Inserir o Script nos alvos
			level1.AddComponent<TargetLevel>();
			level1.GetComponent<TargetLevel>().target = TargetEnum.Level1;

			level2.AddComponent<TargetLevel>();
			level2.GetComponent<TargetLevel>().target = TargetEnum.Level2;

			level3.AddComponent<TargetLevel>();
			level3.GetComponent<TargetLevel>().target = TargetEnum.Level3;

			level1.AddComponent<MeshCollider>();
			level2.AddComponent<MeshCollider>();
			level3.AddComponent<MeshCollider>();
		}
	}
}
