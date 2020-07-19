using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockCollisionOnGround : MonoBehaviour 
{
	public bool isDropped;
	private HoldingRockOnHand holdingRockOnHand;

	private void Awake ()
	{
		holdingRockOnHand = this.GetComponent<HoldingRockOnHand> ();
	}

	private void OnCollisionEnter2D(Collision2D coll) 
	{
		if (coll.gameObject.tag == "Ground")
		{
			isDropped = true;
			holdingRockOnHand.canCollect = false;
		}
	}

}
