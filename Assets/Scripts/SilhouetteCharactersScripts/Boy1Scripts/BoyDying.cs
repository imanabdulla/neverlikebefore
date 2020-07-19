using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoyDying : MonoBehaviour
{
	private Animator animator;


	private void Start ()
	{
		animator = this.GetComponent<Animator> ();
		animator.SetBool ("isRunning", true);
	}


	private void OnTriggerEnter2D (Collider2D col2d)
	{
		if (col2d.gameObject.tag == "Bullet") 
		{
            Debug.Log("BOY DYING");
			animator.SetBool ("isRunning", false);
			GameObject.FindGameObjectWithTag("Finish").GetComponent<BoyInBackground> ().boySpeed = 0;
		}
	}
}
