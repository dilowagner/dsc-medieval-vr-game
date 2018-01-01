using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passage : MonoBehaviour 
{
	private RVPlayer player;
	private Vector3 posInit; // Posicao inicial do player

	// Use this for initialization
	void Start () 
	{
		// Procurar Player na Cena
		player = FindObjectOfType<RVPlayer> ();
		posInit = player.transform.position;
	}

	// Entrar em construções
	public void GetInBuild()
	{
		// Posicao atual antes do teletransporte
		posInit = player.transform.position;
		// Fazer o tele transporte
		player.transform.position = transform.position;
	}

	// Sair de construções
	public void GetOutBuild()
	{
		// POsicao atual antes do teletransporte
		player.transform.position = posInit;
	}
}
