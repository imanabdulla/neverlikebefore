using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : CameraBehavior
{

    [HideInInspector]
    public float yOffset;
    private PlayerDirection playerDirection;
    private CollisionState collisionState;
    private float xVelocity = 0.0f;
    private float yVelocity = 0.0f;
    private float xOffset = 40f;
    private float smoothTime = 1f;
    private float speed = 3f;
    private GameController gameController;

    void Start()
    {
        playerDirection = player.GetComponent<PlayerDirection>();
        collisionState = player.GetComponent<CollisionState>();
        gameController = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameController>();
        yOffset = cameraYPos;
    }

    void Update()
    {
        SetPositionInFrontPlayer();
    }

    private void SetPositionInFrontPlayer()
    {
        /*
         * Position the camera in front of the player.
         */
        var direction = (int)playerDirection.inputState.direction;
        var pos = player.transform.position;
        pos.x = pos.x + (xOffset * direction);
        pos.y = pos.y +  yOffset;
        pos.z = -100f;
        transform.position = SmoothMotion(transform.position, pos, ref xVelocity, ref yVelocity, smoothTime);
    }
}
