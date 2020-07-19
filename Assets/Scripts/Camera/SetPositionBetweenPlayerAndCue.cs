using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPositionBetweenPlayerAndCue : CameraBehavior
{
    [HideInInspector]
    public GameObject Cue;
    [HideInInspector]
    public float xOffset = 30f;
    private bool isCuePresent;
    private float xVelocity = 0.0f;
    private float yVelocity = 0.0f;
    private float smoothTime = 0.75f;

    void Start()
    {
        //isCuePresent = false;
    }

    void Update()
    {
        //if (isCuePresent)
        //{
        if (Cue != null)
        {
            SetCameraBetweenPlayerAndCue(player.transform.position, Cue);
        }
        //}
    }

    //void OnTriggerEnter2D(Collider2D collider)
    //{
    //    if (collider.gameObject.tag.Equals("Player"))
    //    {
    //        isCuePresent = true;
    //    }
    //}

    private void SetCameraBetweenPlayerAndCue(Vector3 position, GameObject cue)
    {
        /*
         * Disable the follow playerbehavior of the camera. 
         */

        /*
         * Get average position between player and cue.
         */
        var averagePos = (cue.transform.position + position) / 2;
        averagePos.x = averagePos.x + xOffset;
        averagePos.y = camera.transform.position.y;
        averagePos.z = -100;

        camera.transform.position = SmoothMotion(camera.transform.position,
            averagePos, ref xVelocity, ref yVelocity, smoothTime);
    }
}
