using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CannonEvent : EventTrigger
{
	public override void OnPointerClick(PointerEventData eventData)
	{
		base.OnPointerClick (eventData);
	}

	public override void OnPointerDown(PointerEventData eventData)
	{
		base.OnPointerDown (eventData);

		// Desativa os componentes do Player
		FindObjectOfType<Bow>().gameObject.SetActive(false);
		//FindObjectOfType<RVPlayer> ();
		GetComponent<Cannon> ().isActived = true;
	}
}
