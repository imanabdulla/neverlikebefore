using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public class GameOver_CaughtByMilitia : MonoBehaviour
    {

        public GameObject Resume;
        public GameObject panelGameOver;


        private void OnEnable()
        {

            GameManger_Master.GameOverCaughtByMilitiaEvent += TurnOnGameOverCaughtByMilitia;
            
        }

        private void OnDisable()
        {
            GameManger_Master.GameOverCaughtByMilitiaEvent -= TurnOnGameOverCaughtByMilitia;
           
        }

        public void TurnOnGameOverCaughtByMilitia()
        {

            if (panelGameOver != null)
            {

                panelGameOver.SetActive(!panelGameOver.activeSelf);
                //Resume.SetActive(false);
                //Time.timeScale = 0;
            }
        }

    }
}