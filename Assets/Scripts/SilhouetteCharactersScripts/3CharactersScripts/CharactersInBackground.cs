using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersInBackground : MonoBehaviour {

	private void Start ()
	{
		this.GetComponent<Animator> ().StartPlayback ();

	}
	void OnTriggerEnter2D (Collider2D col2d)
	{
		if (col2d.gameObject.tag == "Player")
			this.GetComponent<Animator> ().StopPlayback ();
	}
}
