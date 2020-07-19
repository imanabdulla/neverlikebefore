using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace S3
{
    public class GameManger_Exit : MonoBehaviour
    {


       
        private void OnEnable()
        {
           
           GameManger_Master.GameOverEvent += ExitGame;
        }

        private void OnDisable()
        {
          GameManger_Master.GotomenuSceneEvent -= ExitGame;
        }



        public void ExitGame()
        {
            Application.Quit();

        }
    }
}
