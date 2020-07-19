using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public class ShowHelpMenu : MonoBehaviour
    {

        
        public GameObject panelHelpMenu;
        public GameObject panelMenu;


        private void OnEnable()
        {

            GameManger_Master.HelpMenuEvent += TurnOnHelpMenu;
           
        }

        private void OnDisable()
        {
            GameManger_Master.HelpMenuEvent -= TurnOnHelpMenu;
        }

        public void TurnOnHelpMenu()
        {

            if (panelHelpMenu != null)
            {

                panelHelpMenu.SetActive(!panelHelpMenu.activeSelf);
                panelMenu.SetActive(false);
               

            }
        }
    }
}