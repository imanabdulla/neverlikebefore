using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RescuingDog : MonoBehaviour 
{
	private GameObject dog;

	private void Awake ()
	{
		dog = GameObject.FindGameObjectWithTag ("Dog");
		dog.GetComponent<DogCompanion> ().enabled = false;
	}

	private void OnTriggerEnter2D(Collider2D coll2d)
	{
		if (coll2d.gameObject.tag == "Obstacles") 
		{
			dog.GetComponent<DogCompanion> ().enabled = true;
		}
	}

}
