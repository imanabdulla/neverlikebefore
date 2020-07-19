using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableZoomOutCamera : CameraBehavior
{

    void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.tag.Equals("Player"))
        {
            EnableZoomOut();
            DisableZoomIn();
        }
    }

    void OnTriggerExit2D(Collider2D collider2d)
    {
        if (collider2d.tag.Equals("Player"))
        {
            DisableZoomOut();
            EnableZoomIn();
        }
    }
}