using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLevel : MonoBehaviour 
{
	public Target.TargetEnum target = Target.TargetEnum.None;

	private int valLevel1 = 100;
	private int valLevel2 = 50;
	private int valLevel3 = 10;

	void OnCollisionEnter(Collision collision)
	{
		transform.parent.GetComponent<Target> ().particleDust.Play ();

		if (target == Target.TargetEnum.Level1) 
		{
			transform.parent.GetComponent<Target> ().particle100Points.Play ();
		} 
		else if (target == Target.TargetEnum.Level2) 
		{
			transform.parent.GetComponent<Target> ().particle50Points.Play ();
		} 
		else if (target == Target.TargetEnum.Level3) 
		{
			transform.parent.GetComponent<Target> ().particle10Points.Play ();
		}
	}
}
