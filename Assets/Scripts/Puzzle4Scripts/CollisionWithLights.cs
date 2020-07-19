using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithLights : MonoBehaviour 
{
	public bool startMachineShooting = false;


	private void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "PlayerCollider3D") 
		{
			startMachineShooting = true;
		}
	}


	private void OnTriggerExit (Collider col)
	{
		if (col.gameObject.tag == "PlayerCollider3D") 
		{
			startMachineShooting = false;
		}
	}

}
