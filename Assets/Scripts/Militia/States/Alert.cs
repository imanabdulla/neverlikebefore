using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alert : MilitiaState
{
    private Transform[] patrolPoints;
    private Rigidbody2D body2d;
    private int index = 0;
    private Vector2 targetPoint;
    private float xVelocity = 0f;
    private float yVelocity = 0f;
    private float smoothTime = 0.75f;
    private Animator animator;
    private MilitiaStateManager stateManager;

    public Alert(Transform[] patrolPoints, Rigidbody2D body2d, Animator animator, MilitiaStateManager stateManager)
    {
        this.patrolPoints = patrolPoints;
        this.body2d = body2d;
        this.animator = animator;
        this.stateManager = stateManager;
        animator.SetBool("PlayerInSight", false);
    }

    public override void Handle()
    {
        stateManager.InvokeRepeating("Alerting", 1f, 2f);
    }

    private void Alerting()
    {
        body2d.gameObject.transform.localScale = new Vector3(body2d.gameObject.transform.localScale.x * -1,
            body2d.gameObject.transform.localScale.y, body2d.gameObject.transform.localScale.z);
    }
}
