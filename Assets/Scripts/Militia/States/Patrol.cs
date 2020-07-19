using System;
using UnityEngine;

public class Patrol : MilitiaState
{

    private Transform[] patrolPoints;
    private Rigidbody2D body2d;
    private int index = 0;
    private Vector2 targetPoint = Vector2.zero;
    private float xVelocity;
    private float yVelocity;
    private float smoothTime = 1f;
    private bool turned = false;
    private Animator animator;
    public Patrol(Transform[] patrolPoints, Rigidbody2D body2d, Animator animator)
    {
        this.patrolPoints = patrolPoints;
        this.body2d = body2d;
        this.animator = animator;
        animator.SetTrigger("PassedAlertTime");
    }

    public override void Handle()
    {
        if (Mathf.Round(body2d.gameObject.transform.position.x) == Mathf.Round(targetPoint.x))
        {
            // turn the character's face when it reaches the end of the path
            if ((index + 1) >= patrolPoints.Length)
            {
                body2d.gameObject.transform.localScale = new Vector3(body2d.gameObject.transform.localScale.x * -1,
                    body2d.gameObject.transform.localScale.y,
                    body2d.gameObject.transform.localScale.z);
                turned = true;
            }

            // check if the character returned to the start of the path, if it's on the start and it 
            // already turned once, turn the character's face.
            if (turned && index == 0)
            {
                body2d.gameObject.transform.localScale = new Vector3(body2d.gameObject.transform.localScale.x * -1,
                    body2d.gameObject.transform.localScale.y,
                    body2d.gameObject.transform.localScale.z);
                turned = false;
            }

            index = (index + 1) % patrolPoints.Length;
        }
        targetPoint = patrolPoints[index].position;
        body2d.gameObject.transform.position = moveToward(body2d.gameObject.transform.position, targetPoint, ref xVelocity,
          ref yVelocity, smoothTime);

    }
}
