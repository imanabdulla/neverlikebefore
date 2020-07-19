using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : CameraBehavior
{
    void Update()
    {

        //iTween.ShakePosition(camera.gameObject, new Vector3(0.25f, 0.25f, 0f), 5f);
        camera.gameObject.transform.localPosition = camera.gameObject.transform.position + Random.insideUnitSphere * 0.8f;
        //camera.gameObject.transform.localPosition =
        //    new Vector3(camera.gameObject.transform.position.x + Random.insideUnitSphere.x * 0.8f,
        //    camera.gameObject.transform.position.y,
        //    camera.gameObject.transform.position.z + Random.insideUnitSphere.z * 0.8f);
    }

}
