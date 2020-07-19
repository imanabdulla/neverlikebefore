using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogProjectile : MonoBehaviour {


	public GameObject JumpFromPoint;
	public GameObject target;
	public float gravity = 9.8f;
	[HideInInspector]
	public Rigidbody2D DogRg;
	public float throwAngle=45f;
	public float timeToReachTarget=10f;



	// Use this for initialization
	void Start () {
	 DogRg = this.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update ()
	{
		
		float distance = Vector3.Distance (this.transform.position, JumpFromPoint.transform.position);
		if (distance < 5) {


			float targetXDistance = this.transform.position.x - target.transform.position.x;
			float targetYDistance = this.transform.position.y - target.transform.position.y;
			
			float throwAngle;
			throwAngle = Mathf.Atan ((targetYDistance + 4.905f) / distance);

			float totalVelocity = targetXDistance / Mathf.Cos (throwAngle);

			float xVelocity=totalVelocity *Mathf.Cos (throwAngle);
			float yVelocity=totalVelocity *Mathf.Sin (throwAngle);
		

			DogRg.velocity = new Vector2 (xVelocity, yVelocity);             
		}
	}
}

			


		
	
	

	
	

