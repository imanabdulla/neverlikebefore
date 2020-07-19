using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCameraHorizontal : CameraBehavior
{
    public GameObject cue;

    void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.tag.Equals("Player"))
        {
            camera.GetComponent<SetPositionBetweenPlayerAndCue>().Cue = cue;
            camera.GetComponent<SetPositionBetweenPlayerAndCue>().enabled = true;
            camera.GetComponent<FollowPlayer>().enabled = false;
        }
    }


    void OnTriggerExit2D(Collider2D collider2d)
    {
        if (collider2d.tag.Equals("Player"))
        {
            camera.GetComponent<SetPositionBetweenPlayerAndCue>().Cue = null;
            camera.GetComponent<SetPositionBetweenPlayerAndCue>().enabled = false;
            camera.GetComponent<FollowPlayer>().enabled = true;
        }
    }
}