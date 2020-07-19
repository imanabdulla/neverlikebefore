using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraEscapeMilitia : CameraBehavior
{
    public float escapeDistance = 10;
    public GameObject militia;

    void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.tag.Equals("Player"))
        {
            camera.GetComponent<SetPositionBetweenPlayerAndCue>().xOffset += escapeDistance;
            if (militia != null)
            {
                militia.GetComponent<SeePlayer>().playerHiding = true;
            }
        }
    }


    void OnTriggerExit2D(Collider2D collider2d)
    {
        if (collider2d.tag.Equals("Player"))
        {
            this.gameObject.SetActive(false);
            if (militia != null)
            {
                militia.GetComponent<SeePlayer>().playerHiding = false;
            }
        }
    }
}