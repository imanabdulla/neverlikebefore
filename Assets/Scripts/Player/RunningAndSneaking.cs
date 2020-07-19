using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunningAndSneaking : PlayerBehaviors
{
    public float speed = 5;
    public float fraction = 0.5f;
    public AudioClip runningAudioSource1;
    public AudioClip pantingAudioSource2;

	private Animator animator;
	private Jumping jumpingScript;


    protected override void Awake()
    {
        base.Awake();
		animator = this.GetComponent<Animator>();
		jumpingScript = this.GetComponent<Jumping> ();
	}


    private void Update()
    {
        if (GameController.inputEnabled)
        {
            bool right = inputState.GetButtonValue(buttons[0]);
            bool left = inputState.GetButtonValue(buttons[1]);
            bool x = inputState.GetButtonValue(buttons[2]);

            if ((right || left))
            {
                float velX = speed;

                if (x && fraction < 1)
                    velX *= fraction;

                velX = velX * (float)inputState.direction;

				if (animator.GetInteger("AnimState") == 1000 || jumpingScript.isReadyToJump)
					body2d.velocity = new Vector2 (0, 0);					
				else
					body2d.velocity = new Vector2 (velX, body2d.velocity.y);


                if (!source1.isPlaying)
                {
                    source1.PlayOneShot(runningAudioSource1, 0.5f);
                    source2.PlayOneShot(pantingAudioSource2, 0.5f);
                    GameController.audioIsPlaying = true;
                }


            }

            else
            {
                body2d.velocity = new Vector2(0, body2d.velocity.y);
                source1.Stop();
                source2.Stop();
                GameController.audioIsPlaying = false;
            }
        }
    }
}
