using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UnloadScene : MonoBehaviour {


    public void Unload(string scene)
    {
        SceneManager.sceneUnloaded += NotifyWhenSceneIsUnloaded;
        SceneManager.UnloadSceneAsync(scene);
    }

    private void NotifyWhenSceneIsUnloaded(Scene scene)
    {
        SceneManager.sceneUnloaded -= NotifyWhenSceneIsUnloaded;
        //SceneManager.SetActiveScene(scene);
    }
}
