using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public BoxCollider2D GameBoundaries;
    [HideInInspector]
    public float cameraStartingYPosition;
    [HideInInspector]
    public static bool dialoguePresent;
    [HideInInspector]
    public static bool inputEnabled;
    [HideInInspector]
    public static bool audioIsPlaying;

    void Start()
    {
        var mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        cameraStartingYPosition = mainCamera.transform.position.y;
    }

    public Rect GetSceneBoundaries()
    {

        var boundingBox = GameBoundaries.bounds;
        var sceneBound = new Rect(boundingBox.min.x, boundingBox.min.y, boundingBox.size.x, boundingBox.size.y);
        return sceneBound;
    }



}
