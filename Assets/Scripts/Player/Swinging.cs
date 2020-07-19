using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swinging : MonoBehaviour {
	public GameObject obj;
	private void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			col.gameObject.transform.SetParent (col.gameObject.transform);
		}
	}

}
