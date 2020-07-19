using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace S3
{
    public class GameManger_GotoMenuScene : MonoBehaviour
    {

     
        private void OnEnable()
        {
            
            GameManger_Master.GotomenuSceneEvent += GoToMENUScene;
        }

        private void OnDisable()
        {
            GameManger_Master.GotomenuSceneEvent -= GoToMENUScene;
        }

       
        public void GoToMENUScene()
        {
            SceneManager.LoadScene(0);
          
        }
    }
}
