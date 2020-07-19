using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingTheBoy : MonoBehaviour 
{
	public bool startMachineShooting;

	private void OnTriggerEnter2D (Collider2D col2d) 
	{
		if (col2d.gameObject.tag == "SilhouetteBoy") 
		{
			startMachineShooting = true;
		}
	}
}
