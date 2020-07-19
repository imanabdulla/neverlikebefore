using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3 { 
public class GameOver_Safocating : MonoBehaviour {

    public GameObject Resume;
    public GameObject panelGameOver;


        private void OnEnable()
        {

            GameManger_Master.GameOverSuffocatingEvent += TurnOnGameOver;
        }

        private void OnDisable()
        {
            GameManger_Master.GameOverSuffocatingEvent -= TurnOnGameOver;
        }

        public void TurnOnGameOver()
    {

        if (panelGameOver != null)
        {

            panelGameOver.SetActive(!panelGameOver.activeSelf);
            
        }
    }

}
}

