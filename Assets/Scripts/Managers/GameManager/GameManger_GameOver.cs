using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public class GameManger_GameOver : MonoBehaviour
    {
        public GameObject Resume;
        public  GameObject panelGameOver;
        

        private void OnEnable()
        {
            
            GameManger_Master.GameOverEvent += TurnOnGameOverBomb;
        }

        private void OnDisable()
        {
            GameManger_Master.GameOverEvent -= TurnOnGameOverBomb;
        }

        public  void TurnOnGameOverBomb()
        {

            if(panelGameOver != null)
            {
                
                panelGameOver.SetActive(!panelGameOver.activeSelf);
               // GameManger_Master.isMenuOn = !GameManger_Master.isMenuOn;
                Resume.SetActive(false);

            }
        }

    }
}
