using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomIn : CameraBehavior {

    void Update()
    {
        /*
         * Zoom in to the player (and target).   
         */
        StartCoroutine("ZoomInToPlayer");
    }

    IEnumerator ZoomInToPlayer()
    {
        while (camera.orthographicSize > CAMERA_SIZE_ZOOM_IN)
        {

            yield return new WaitForSeconds(0.1f);
            camera.orthographicSize -= 0.001f;
        }
    }
}
