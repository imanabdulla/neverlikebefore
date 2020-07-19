using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Chase : MilitiaState
{

    private GameObject player;
    private LayerMask layer;
    private Rigidbody2D body2d;
    private RaycastHit2D hitRight;
    private RaycastHit2D hitLeft;
    private Vector2 downwardVector;
    private float maxDownDistance = 6f;
    private float maxXDistance = 8f;
    private float maxYDistance = 12f;

    private float maxHeight = 20f;
    private float maxRadiusDetectCollision = 3f;
    private float maxRadiusDetectObstacle = 10f;
    private float xOffset = 6f;
    private float minDistanceToPlayer = 6f;
    private float xVelocity = 0;
    private float yVelocity = 0;
    private float smoothTime = 3f;
    private Transform militiaTransform;
    private bool gameOver = false;
    private Animator animator;
    private bool isJumping = false;
    private SeePlayer seePlayer;
    private bool onGround = false;

    

    public Chase(Rigidbody2D body2d, GameObject target, LayerMask layer, Animator animator)
    {
        this.body2d = body2d;
        this.player = target;
        this.layer = layer;
        this.animator = animator;
        this.militiaTransform = body2d.gameObject.transform;
        animator.SetBool("PlayerInSight", true);

        if (Mathf.Sign(militiaTransform.localScale.x) < 0)
        {
            militiaTransform.localScale = new Vector3(militiaTransform.localScale.x * -1,
                     militiaTransform.localScale.y,
                     militiaTransform.localScale.z);
        }
        seePlayer = body2d.GetComponent<SeePlayer>();
    }

    public override void Handle()
    {
        /*
         * move militia to player. 
         */
        militiaTransform.position = moveToward(militiaTransform.position, player.transform.position,
            ref xVelocity, ref yVelocity, smoothTime);

        /*
         * get vector to detect collision between militia and ground. 
         */
        downwardVector = new Vector2(militiaTransform.position.x, militiaTransform.position.y - 3f);

        /*
         * shoot a raycast to detect obstacles infront of militia.  
         */
        hitRight = Physics2D.Raycast(
            new Vector2(militiaTransform.position.x + xOffset, militiaTransform.position.y + maxYDistance)
            , -1 * militiaTransform.right, maxXDistance);

        hitLeft = Physics2D.Raycast(
          new Vector2(militiaTransform.position.x + xOffset, militiaTransform.position.y + maxYDistance)
          , militiaTransform.right, maxXDistance);  

        Debug.DrawRay(new Vector2(militiaTransform.position.x + xOffset, militiaTransform.position.y + maxYDistance),
            -1 * militiaTransform.right * maxXDistance, Color.red);

        /* 
         * Change animation of militia. 
         */
        //Debug.Log("MILITIA COLLISION: " + Physics2D.Raycast(
        //  militiaTransform.transform.position + new Vector3(3, 3), militiaTransform.up * -1 * 0.1f, layer).collider.tag);

        Debug.DrawRay(militiaTransform.transform.position + new Vector3(3, 5.5f), militiaTransform.up * -1 *3f, Color.yellow);

        if (!Physics2D.Raycast(
          militiaTransform.transform.position + new Vector3(3,5.5f), militiaTransform.up * -1, 3, layer))
        {
            isGrounded = false;
            if (!isJumping)
            {
                animator.SetTrigger("Jump");
                isJumping = true;
            }
        }
        else
        {
            isGrounded = true;

            animator.SetTrigger("OnGround");
            isJumping = false;
        }

        Debug.Log("HIT LEFT" + hitLeft.collider.gameObject.tag);
        //Debug.Log("HIT RIGHT" + hitRight.collider.gameObject.tag);

        /*
         * check obstacles height in front of militia. 
         */
        if (hitLeft || hitRight)
        {

            /*
             * check if militia reached player. 
             */
            if (hitLeft.collider.gameObject.tag.Equals("Player") || hitRight.collider.gameObject.tag.Equals("Player"))
            {
                Debug.Log("Militia caught player");
                if (!gameOver)
                {
                    S3.GameManger_Master.CallGameOverCaughtByMilitia();
                    gameOver = true;
                }
            }
            else
            {
                if (hitLeft.collider.gameObject.tag.Equals("Platform") || hitRight.collider.gameObject.tag.Equals("Platform"))
                {
                    {
                        //Debug.Log(" HEELLOOOOO obstacle " + hit.collider.bounds.size.y + " Max height" + maxHeight);
                        if (hitLeft.collider.bounds.size.y > maxHeight || hitRight.collider.bounds.size.y > maxHeight)
                        {
                            Debug.Log("Cant move further");
                            seePlayer.playerHiding = true;

                        }
                        else
                        {
                            if (!isJumping)
                            {
                                animator.SetTrigger("Jump");
                                isJumping = true;
                                body2d.position = new Vector2(body2d.position.x, body2d.position.y + 30);
                            }
                        }
                    }
                }

            }
        }
    }
}