using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitCameraPosition : CameraBehavior
{
    private bool isFreezed = false;


    void Update()
    {
        if (isFreezed)
        {
            FreezeCameraMove();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            isFreezed = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag.Equals("Player"))
        {
            isFreezed = false;
            /*
             * Enable the follow player behavior of the camera.
             */
            EnableFollowPlayerBehavior();
        }
    }

    private void FreezeCameraMove()
    {
        /*
         * Disable the follow player behavior of the camera. 
         */
        DisableFollowPlayerBehavior();
        FreezePlayerPosition();
    }
}
