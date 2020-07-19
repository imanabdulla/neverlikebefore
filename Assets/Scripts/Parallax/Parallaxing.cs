using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{
    public Transform[] parallaxLayers;
    public float smooth;
    private GameObject mainCamera;
    private Vector3 prevCameraPosition;
    private float[] parallaxValues;
    private Vector3 velocity = Vector3.zero;

    void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Start()
    {
        prevCameraPosition = mainCamera.transform.position;
        parallaxValues = new float[parallaxLayers.Length];
        for (int i = 0; i < parallaxValues.Length; i++)
        {
            parallaxValues[i] = (i) * 2f/ 900 + 0.03f;
        }

    }
    void Update()
    {
        for (int i = 0; i < parallaxLayers.Length; i++)
        {
            float parallax = (prevCameraPosition.x - mainCamera.transform.position.x) * parallaxValues[i];
            Vector3 parallaxLayerTargetPosition = new Vector3(parallaxLayers[i].transform.position.x + parallax,
                parallaxLayers[i].transform.position.y,
                parallaxLayers[i].transform.position.z);

            parallaxLayers[i].transform.position = Vector3.SmoothDamp(parallaxLayers[i].transform.position,
                parallaxLayerTargetPosition, ref velocity, smooth * Time.smoothDeltaTime);
        }
        prevCameraPosition = mainCamera.transform.position;
    }
}
