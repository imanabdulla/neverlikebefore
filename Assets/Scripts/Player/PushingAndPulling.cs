using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushingAndPulling : MonoBehaviour
{
	public Buttons[] btn;
    public CollisionWithGround colWithGround;
    public float forceFactor;
    public bool isReadyToPush = false;
    public AudioClip dragAudioSource1;
    private Rigidbody2D obstacleBody2d;
	private InputState inputState;
	private FixedJoint2D joint2d;
    private AudioSource audioSource;

	private void Awake ()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        inputState = player.GetComponent<InputState> ();
        audioSource = this.GetComponent<AudioSource>();
        obstacleBody2d = this.GetComponent<Rigidbody2D> ();
		joint2d = this.GetComponent<FixedJoint2D> ();
		joint2d.enabled = false;
        colWithGround.isOnAir = false;
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
                    PushOrPull(forceFactor);
                }
                else
                    Leave();
            }

            else if (!isReadyToPush)
            {
                Leave();
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


	private void PushOrPull(float factor)
    {
		joint2d.enabled = true;
        obstacleBody2d.bodyType = RigidbodyType2D.Dynamic;
        Vector2 pushingForce = new Vector2(obstacleBody2d.mass * obstacleBody2d.gravityScale * (float)inputState.direction * factor, 0);

        obstacleBody2d.AddForce (pushingForce, ForceMode2D.Force);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(dragAudioSource1, 0.5f);
        }

    }


	private void Leave()
	{
		if (colWithGround.isOnAir)
		{
			obstacleBody2d.bodyType = RigidbodyType2D.Dynamic;
		}
		else 
		{
			obstacleBody2d.bodyType = RigidbodyType2D.Static;
        }
        joint2d.enabled = false;
        audioSource.Stop();
    }
}
