using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace S3
{
    public class GameManger_ToggleMenu : MonoBehaviour
    {
        public GameObject gameOverBomb;
        public GameObject gameOverBullet;
        public GameObject gameOverSuffocating;
        public GameObject gameOverCaughtByMilitia;
        public GameObject gameOverWoodBomb;
        public GameObject helpMenu;
        public GameObject settingsMenu;

        public GameObject Menu;
	

        private void Update()
        {
            CheckForMenuToggleRequest();
        }
        private void OnEnable()
        {

            //GameManger_Master.GameOverEvent += ToggleMenu;
            //GameManger_Master.GameOverBulletEvent += ToggleMenu;
            //GameManger_Master.GameOverSuffocatingEvent += ToggleMenu;
            //GameManger_Master.GameOverCaughtByMilitiaEvent += ToggleMenu;
            //GameManger_Master.GameOverWoodBomb += ToggleMenu;



        }

        private void OnDisable()
        {
            // GameManger_Master.GameOverEvent -= ToggleMenu;
            //GameManger_Master.GameOverBulletEvent -= ToggleMenu;
            //GameManger_Master.GameOverSuffocatingEvent -= ToggleMenu;
            //GameManger_Master.GameOverCaughtByMilitiaEvent -= ToggleMenu;
            //GameManger_Master.GameOverWoodBomb -= ToggleMenu;








        }

        void CheckForMenuToggleRequest()
        {
            if (Input.GetKeyUp(KeyCode.Escape) && !GameManger_Master.isGameOver && !GameManger_Master.isInventory)
            {
                ToggleMenu();

            }
        }

        public void ToggleMenu()
        {
            if (Menu != null)
            {


                Menu.SetActive(!Menu.activeSelf);

                GameManger_Master.CallEventMenuToggle();//fireing

                gameOverBomb.SetActive(false);
                gameOverBullet.SetActive(false);
                gameOverSuffocating.SetActive(false);
                gameOverCaughtByMilitia.SetActive(false);
                gameOverWoodBomb.SetActive(false);




            }
            else
            {
                Debug.LogWarning("Assign menu");
            }
        }



        public void Back()
        {

            helpMenu.SetActive(false);
            settingsMenu.SetActive(false);
            gameOverBomb.SetActive(false);
            gameOverBullet.SetActive(false);
            gameOverSuffocating.SetActive(false);
            gameOverCaughtByMilitia.SetActive(false);
            gameOverWoodBomb.SetActive(false);



            Menu.SetActive(true);

        }


    }
}
