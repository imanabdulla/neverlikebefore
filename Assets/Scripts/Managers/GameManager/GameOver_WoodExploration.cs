using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace S3 { 
public class GameOver_WoodExploration : MonoBehaviour {
    public GameObject Resume;
    public GameObject panelGameOver;


    private void OnEnable()
    {

        GameManger_Master.GameOverWoodBomb += TurnOnGameOverWoodBomb;
    }

    private void OnDisable()
    {
        GameManger_Master.GameOverWoodBomb -= TurnOnGameOverWoodBomb;
    }

    public void TurnOnGameOverWoodBomb()
    {

        if (panelGameOver != null)
        {

            panelGameOver.SetActive(!panelGameOver.activeSelf);
            Resume.SetActive(false);
        }
    }

}
}