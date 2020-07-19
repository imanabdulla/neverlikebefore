using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBehaviors : MonoBehaviour 
{
	public Buttons[] buttons;
	protected Rigidbody2D body2d;
    [HideInInspector]
    public InputState inputState;
	protected CollisionState collisionState;
	protected float absVelX;
	protected float absVelY;
    protected AudioSource source1;
    protected AudioSource source2;

	protected virtual void Awake () 
	{
		body2d = this.GetComponent<Rigidbody2D> ();	
		inputState = this.GetComponent<InputState> ();
		collisionState = this.GetComponent <CollisionState> ();
        source1 = this.GetComponent<AudioSource>();
        source2 = this.GetComponent<AudioSource>();
	}
		
	protected virtual void FixedUpdate() 
	{
		absVelX = Mathf.Abs (body2d.velocity.x);
		absVelY = Mathf.Abs (body2d.velocity.y);
	}
}
