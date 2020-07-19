using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace S3
{
    public class GameManger_RestartLevel : MonoBehaviour
    {

       


        public  void RestartLevel()
        {

            Time.timeScale = 1;
            SceneManager.LoadScene(1);
        }

    }
}
