
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SetPositionBetweenPlayerBombCue : CameraBehavior
{
    [HideInInspector]
    public static List<GameObject> bombsCue;
    private bool isBombPresent = false;
    private float xVelocity = 0.0f;
    private float yVelocity = 0.0f;
    private float smoothTime = 0.75f;
    private bool subscribed = false;

    void Start()
    {
        bombsCue = new List<GameObject>();
    }

    void Update()
    {
        if (isBombPresent)
        {
            SetCameraPosition(player.transform.position, bombsCue);
        }
    }

    private void SetCameraPosition(Vector3 player, List<GameObject> cues)
    {
        /*
         * If no bombs are no more in the scene.
         */
        if (cues.Count == 0)
        {
            isBombPresent = false;

            /*
             * Disable zoom out behavior. 
             */
            DisableZoomOut();

            /*
             * Enable zoom in behavior. 
             */
            EnableZoomIn();

            Invoke("StopCameraShake", 2);
            return;
        }

        /*
         * Disable zoom in behavior. 
         */
        DisableZoomIn();

        /*
         * Enable zoom out behavior. 
         */
        EnableZoomOut();

        /*
         * Get the average position between the bombs. 
         */
        Vector3 sumOfPositions = Vector3.zero;
        for (int i = 0; i < cues.Count; i++)
        {
            sumOfPositions = sumOfPositions + cues[i].transform.position;
        }
        var bombsAveragePosition = sumOfPositions / cues.Count;
        /*
         * Get average position between bombs average position and player.
         */
        var averagePos = (bombsAveragePosition + player) / 2;
        averagePos.y = camera.transform.position.y;
        averagePos.z = -1;

        camera.transform.position = SmoothMotion(camera.transform.position,
            averagePos, ref xVelocity, ref yVelocity, smoothTime);
    }


    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.gameObject.tag.Equals("Player"))
        {
            /*
             * Subscribe to the explosion event. 
             */
            Subscribe();
            if (bombsCue.Count > 0)
            {
                isBombPresent = true;
            }
        }
    }

    private void Subscribe()
    {

        if (bombsCue.Count > 0)
        {
            /*
             * Subscribe to the explosion event. 
             */
            foreach (var bomb in bombsCue)
            {
                bomb.GetComponent<S3.Bomb>().explode += Shake;
            }
        }
    }

    private void StopCameraShake()
    {
        if (shaking)
        {
            Unshake();
        }
    }
}
