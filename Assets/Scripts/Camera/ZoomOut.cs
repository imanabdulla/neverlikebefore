using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : CameraBehavior {
    public float value;

    void Update()
    {
        /*
        * Zoom out to fit screen.   
        */
        StartCoroutine("ZoomOutToFitScreen");
    }
    IEnumerator ZoomOutToFitScreen()
    {
        if (value == 0 || value < CAMERA_SIZE_ZOOM_OUT)
        {
            value = CAMERA_SIZE_ZOOM_OUT;
        }
        while (camera.orthographicSize < value)
        {
            yield return new WaitForSeconds(0.1f);
            camera.orthographicSize += 0.005f;
        }
    }

}
