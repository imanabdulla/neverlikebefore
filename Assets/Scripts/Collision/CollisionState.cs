using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionState : MonoBehaviour {
	public bool isStanding;
	public Vector3 collisionCenterPoint = Vector3.zero;
	public float collisionRadius;
	public LayerMask collisionLayer;
	public Color collisionColor = Color.red;

	void FixedUpdate () {
		
		Vector3 pos = collisionCenterPoint;
		pos.x += this.transform.position.x;
		pos.y += this.transform.position.y;
		//to draw circle and check if it collids with the collisionLayer's objects or not 
		//isStanding = Physics.OverlapSphere (pos, collisionRadius,collisionLayer)[0];
		isStanding = Physics2D.OverlapCircle (pos, collisionRadius,collisionLayer);

		/*Collider[] hitColliders = Physics.OverlapSphere (pos, collisionRadius,collisionLayer);

		if (hitColliders.Length != 0)
			isStanding = true;
		else
			isStanding = false;*/
	}

	private void OnDrawGizmos () {
		Gizmos.color = collisionColor;
		Vector3 pos = collisionCenterPoint;
		pos.x += this.transform.position.x;
		pos.y += this.transform.position.y;
		Gizmos.DrawWireSphere (pos, collisionRadius);
	}
}
