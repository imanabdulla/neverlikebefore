using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingRockOnHand : MonoBehaviour 
{
	[HideInInspector]
	public Collider2D pivotCollider;
	//[HideInInspector]
	public bool canCollect = false;
	public string tagName = "Pivot";


	private void OnTriggerEnter2D (Collider2D pivotCollider) 
	{
		if (pivotCollider.gameObject.tag == tagName)
		{
			//colliderOfPivot of Masah hand pivot
			this.pivotCollider = pivotCollider;
			canCollect = true;
		}
	}
}
