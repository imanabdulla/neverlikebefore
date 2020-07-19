using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingObject : MonoBehaviour
{
	public Buttons[] btn;
    public CollisionWithGround colWithGround;
    public float forceFactor, playerSpeed;
	public bool isReadyToPush = false;
    public AudioClip dragAudioSource1;
    private Rigidbody2D obstacleBody2d;
	private InputState inputState;
	private RunningAndSneaking runningScript;
	private FixedJoint2D joint2d;
    private AudioSource audioSource;

	private void Awake ()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        inputState = player.GetComponent<InputState> ();
		runningScript = player.GetComponent<RunningAndSneaking> ();
        audioSource = this.GetComponent<AudioSource>();
        obstacleBody2d = this.GetComponent<Rigidbody2D> ();
		joint2d = this.GetComponent<FixedJoint2D> ();
		joint2d.enabled = false;
        colWithGround.isOnAir = false;
		playerSpeed = runningScript.speed;
	}

    private void Update()
    {
        if (GameController.inputEnabled)
        {
            bool right = inputState.GetButtonValue(btn[0]);
            bool left = inputState.GetButtonValue(btn[1]);
            bool ctrl = inputState.GetButtonValue(btn[2]);

            if (isReadyToPush)
            {
                if ((right || left) && ctrl)
                {
                    PushObject(forceFactor);
                }
                else
				{
                    LeaveObject();

				}
			}

            else if (!isReadyToPush)
            {
                LeaveObject();
            }
        }
    }

	private void OnTriggerEnter2D (Collider2D coll)
    {
        if (coll.gameObject.tag == "Pivot")
            isReadyToPush = true;
	}

	private void OnTriggerExit2D (Collider2D coll)
    {
		if (coll.gameObject.tag == "Pivot")
			isReadyToPush = false;
	}


	private void PushObject(float factor)
    {
		runningScript.speed = playerSpeed  * runningScript.fraction;

		joint2d.enabled = true;
        obstacleBody2d.bodyType = RigidbodyType2D.Dynamic;
        Vector2 pushingForce = new Vector2(obstacleBody2d.mass * obstacleBody2d.gravityScale * (float)inputState.direction * factor, 0);
        obstacleBody2d.AddForce (pushingForce, ForceMode2D.Force);
        
		if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(dragAudioSource1, 0.5f);
        }
    }


	private void LeaveObject()
	{
		if(runningScript.speed < playerSpeed)
			runningScript.speed = playerSpeed;

		if (colWithGround.isOnAir)
			obstacleBody2d.bodyType = RigidbodyType2D.Dynamic;

		else 
			obstacleBody2d.bodyType = RigidbodyType2D.Static;
  
        joint2d.enabled = false;
        audioSource.Stop();
    }
}
