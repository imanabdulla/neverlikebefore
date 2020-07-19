using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDragging : MonoBehaviour {
	#region Fields
	public float maxStretch = 3f;
	public LineRenderer catapultLineFront;
	public LineRenderer catapultLineBack;
	private SpringJoint2D spring;
	private Rigidbody2D body2d;
	private Transform catapult;
	private Ray rayToMouse;
	private Ray leftCatapultToProjectile;
	private float maxStretchSqrt;
	private float circleRadius;
	private bool clickedOn;
	private Vector2 prevVelocity;

	#endregion

	void Awake ()
	{
		spring = GetComponent<SpringJoint2D> ();
		body2d = GetComponent<Rigidbody2D> ();
		catapult = this.spring.connectedBody.transform;
	}

	void Start () 
	{
		LineRendererSetup ();
		rayToMouse = new Ray (catapult.position, Vector3.zero);
		rayToMouse = new Ray (catapultLineBack.transform.position, Vector3.zero);
		CircleCollider2D circle = GetComponent<CircleCollider2D> ();
		circleRadius = circle.radius;
		leftCatapultToProjectile = new Ray (catapultLineFront.transform.position, Vector3.zero);
		maxStretchSqrt = maxStretch * maxStretch;
	}
	

	void Update () 
	{
		// if mouse is Clicked down
		if (clickedOn)
			Dragging ();
		
		if (spring != null) 
		{
			if (body2d.bodyType != RigidbodyType2D.Kinematic && prevVelocity.sqrMagnitude > this.body2d.velocity.sqrMagnitude) 
			{
				Destroy (spring);
				this.body2d.velocity = prevVelocity;
			}
			if (!clickedOn)
				prevVelocity = this.body2d.velocity;

			LineRendererUpdate ();
		}
		else 
		{
			catapultLineFront.enabled = false;
			catapultLineBack.enabled = false;

		}
	}

	void LineRendererSetup ()
	{
		//set first point position of line 
		catapultLineFront.SetPosition (0, catapultLineFront.transform.position);
		catapultLineBack.SetPosition (0, catapultLineBack.transform.position);

		//set sortingLayer name and order
		catapultLineFront.sortingLayerName = "Smoke";
		catapultLineBack.sortingLayerName = "Smoke";
		catapultLineFront.sortingOrder = 3;
		catapultLineBack.sortingOrder = 1;

	}

	void OnMouseDown ()
	{
		spring.enabled = false;
		clickedOn = true;
	}

	void OnMouseUp ()
	{
		spring.enabled = true;
		body2d.bodyType = RigidbodyType2D.Dynamic;
		clickedOn = false;
	}

	void Dragging ()
	{
		//mouse position
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		//mouse to catapult position
		Vector3 catapultToMouse = mouseWorldPoint - catapultLineBack.transform.position;
		//check if the distance between catapult and mouse > the maxStrech
		if (catapultToMouse.sqrMagnitude > maxStretchSqrt) 
		{
			//set the line renderer direction
			rayToMouse.direction = catapultToMouse;
			//set the new position of mouse
			mouseWorldPoint = rayToMouse.GetPoint (maxStretchSqrt);
		}
		mouseWorldPoint.z = 0;
		//set the position of asteriod 
		this.transform.position = mouseWorldPoint;
	}

	void LineRendererUpdate ()
	{
		Vector2 catapultToProjectile = transform.position - catapultLineFront.transform.position;
		leftCatapultToProjectile.direction = catapultToProjectile;
		Vector3 holdPoint = leftCatapultToProjectile.GetPoint (catapultToProjectile.magnitude + circleRadius);
	
		catapultLineFront.SetPosition (1, holdPoint);
		catapultLineBack.SetPosition (1, holdPoint);

	}
}
