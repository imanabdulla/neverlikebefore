using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneUnLoaderController : MonoBehaviour
{

    public string sceneBefore;
    public string sceneAfter;

    private GameObject gameManager;
    private GameObject gameObjectColliderAtBeginning;
    private GameObject gameObjectColliderAtEnd;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameObjectColliderAtBeginning = transform.parent.GetChild(0).gameObject;
        gameObjectColliderAtEnd = transform.parent.GetChild(2).gameObject;
    }

    void OnTriggerEnter2D()
    {
        var sceneBoundary = gameManager.GetComponent<GameController>().GetSceneBoundaries();
        var unloadScene = new UnloadScene();

        unloadScene.Unload(sceneBefore);
        unloadScene.Unload(sceneAfter);

        /*
         * set the load scene collider at the beginning of the scene active
         */
        gameObjectColliderAtBeginning.SetActive(true);

        /*
         * set the load scene collider at the end of the scene active
         */
        gameObjectColliderAtEnd.SetActive(true);
    }
}
