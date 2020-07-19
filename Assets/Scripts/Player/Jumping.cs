using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumping : PlayerBehaviors
{
    public float jumpingSpeed = 20;
	public bool startJumpingAnimation = false;

    private bool space;
    private float holdTime;
	public bool isReadyToJump = false;

    private void Update()
    {
        if (GameController.inputEnabled)
        {
         
            space = inputState.GetButtonValue(buttons[0]);
            holdTime = inputState.GetButtonHoldTime(buttons[0]);

            if (collisionState.isStanding)
            {
                if (space && holdTime < 0.1f)
                {
					startJumpingAnimation = true;
					isReadyToJump = true;
                }
            }
        }
    }


	public  void Jump()
    {
		isReadyToJump = false;
        body2d.velocity = new Vector2(body2d.velocity.x, jumpingSpeed);


    }
}
