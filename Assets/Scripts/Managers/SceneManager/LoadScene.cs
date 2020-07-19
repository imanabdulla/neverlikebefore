using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour {

    void Awake()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        var mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        var gameManager = GameObject.FindGameObjectWithTag("GameManager");
        var inputManager = GameObject.FindGameObjectWithTag("InputManager");
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(mainCamera);
        DontDestroyOnLoad(gameManager);
        DontDestroyOnLoad(inputManager);
    }

    public void Load(string scene)
    {
        /*
         * Register a delegate to be called when the scene is loaded.
         */
        SceneManager.sceneLoaded += NotifyWhenSceneIsLoaded;

        /*
         * Load scene with additive scene mode not to delete the current scene. 
         */
        SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
    }

    private void NotifyWhenSceneIsLoaded(Scene scene, LoadSceneMode mode)
    {
        SceneManager.SetActiveScene(scene);
        SceneManager.sceneLoaded -= NotifyWhenSceneIsLoaded;
    }
}
