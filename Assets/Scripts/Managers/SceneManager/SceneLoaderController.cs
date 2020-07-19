using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoaderController : MonoBehaviour
{

    public string scene;
    private GameObject gameManager;

    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

    void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.tag.Equals("Player"))
        {
            /*
             * set load scene collider inactive. 
             */
            gameObject.SetActive(false);
            var loadScene = new LoadScene();

            if (!scene.Equals(""))
            {
                loadScene.Load(scene);
            }
        }
    }
}
