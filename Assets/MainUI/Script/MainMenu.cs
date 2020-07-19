using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace S3
{
    public class MainMenu : MonoBehaviour
    {

        // Use this for initialization
       public void PlayGame()
        {
            SceneManager.LoadScene(0);

        }

        // Update is called once per frame
        public void ExitGame()
        {
            
            Application.Quit();
        }
    }

}
