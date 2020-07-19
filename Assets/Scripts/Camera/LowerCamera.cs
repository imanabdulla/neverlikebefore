using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerCamera : CameraBehavior
{
    public float cameraYPosTrigger = -3f;  
    public bool zoomOut;
    private float xVelocity = 0.0f;
    private float yVelocity = 0.0f;
    private float smoothTime = 1f;
    void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.tag.Equals("Player"))
        {
            followPlayer.yOffset = cameraYPosTrigger;
            if (zoomOut)
            {
                DisableZoomIn();
                EnableZoomOut();
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider2d)
    {
        if (collider2d.tag.Equals("Player"))
        {
            followPlayer.yOffset = cameraYPos;
            if (zoomOut)
            {
                EnableZoomIn();
                DisableZoomOut();
                zoomOut = false;
            }
            //this.gameObject.SetActive(false);
        }
    }
}
