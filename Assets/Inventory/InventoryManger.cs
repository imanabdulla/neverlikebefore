using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public class InventoryManger : MonoBehaviour
    {

        public string ToggleInventoryButton;
        public GameObject panelInventory;


        private void OnEnable()
        {

            GameManger_Master.InventoryUIToggleEvent += ShowPanelInventory;


        }


        private void OnDisable()
        {

            GameManger_Master.InventoryUIToggleEvent -= ShowPanelInventory;


        }



        void Update()
        {

            CheckForInventoryUI();
        }

        void CheckForInventoryUI()
        {
            if (Input.GetButtonUp("InventoryButton"))
            {

                //ShowPanelInventory();
                GameManger_Master.CallEventInventoryUIToggle();
            }
        }

        public void ShowPanelInventory()
        {

            if (panelInventory != null)
            {

                panelInventory.SetActive(!panelInventory.activeSelf);

            }
        }

    }
}
