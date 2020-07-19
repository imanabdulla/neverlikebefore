using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeePlayer : MonoBehaviour
{
    public LayerMask playerLayer;
    public Transform player;

    [HideInInspector]
    public bool playerInSight;
    [HideInInspector]
    public bool playerHiding = false;

    private float range;
    private float fieldOfView = 114f;
    private Rigidbody2D body2d;
    private Vector2 directionToPlayer;
    private Vector2 lineOfSight;
    private Vector2 lineOfSightEnd;
    private bool playerIsWithinRange = false;
    private float angleBetweenPlayerAndEnemy;
    private RaycastHit2D hit;

    void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (playerHiding)
        {
            range = 1f;
        }
        else
        {
            range = 76f;
        }

        lineOfSightEnd = new Vector2(body2d.position.x + range, body2d.position.y);
        directionToPlayer = (Vector2)player.position - body2d.position;
        lineOfSight = lineOfSightEnd - body2d.position;
        angleBetweenPlayerAndEnemy = Vector2.Angle(directionToPlayer, lineOfSight);

        if (playerIsWithinRange)
        {
            // check if something is blocking the militia's sight to player
            hit = Physics2D.Raycast(body2d.position, directionToPlayer, range, playerLayer);
            if (hit)
            {
                if (hit.collider.tag.Equals("Player"))
                {
                    if (angleBetweenPlayerAndEnemy <= fieldOfView)
                    {
                        playerInSight = true;
                    }
                    else
                    {
                        playerInSight = false;
                    }
                }

            }
        }
        else
        {
            playerInSight = false;
        }

    }

    void FixedUpdate()
    {
        playerIsWithinRange = Physics2D.OverlapCircle(body2d.position,
            range, playerLayer);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(body2d.position, range);
        Gizmos.DrawLine(lineOfSightEnd, body2d.position);
        Gizmos.DrawLine((Vector2)player.position, body2d.position);
    }
}
