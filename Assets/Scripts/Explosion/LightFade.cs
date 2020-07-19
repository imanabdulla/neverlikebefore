using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFade : MonoBehaviour {

    private Light pointLight;

	void Start () {
        pointLight = GetComponent<Light>();	
	}
	
	void Update () {
        pointLight.range = Mathf.Lerp(pointLight.range, 0f, Time.deltaTime);
	}
}
