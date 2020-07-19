using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionOnGround : MonoBehaviour {
	public bool done;

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Ground")
		{
			done = true;
		}
	}

}
