using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlRank : MonoBehaviour 
{
	// Contador de Rank
	public int rank = 0;
	public Text points;
		
	// Update is called once per frame
	void Update () 
	{
		Debug.Log ("Pontuacao: " + rank.ToString());
		//points.text = rank.ToString ();	
	}
}
