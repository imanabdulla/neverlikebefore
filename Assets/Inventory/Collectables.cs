using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3 
{
    public class Collectables : MonoBehaviour
    {
        float distance = 10f;
        [HideInInspector]
        public bool isSuffocatted, maskIsCollected;
        public GameObject RewardDragArea;
        public GameObject RewardTarget;
        public GameObject InventoryPanel;
        public GameObject maskPivot;

        private void Start()
        {
            Vector3 startPosition = transform.position;
            Physics2D.queriesHitTriggers = true;
            isSuffocatted = true; maskIsCollected = false;
           
        }


        private void OnMouseDown()
        {

            if (InventoryPanel != null)
            {

                transform.position = RewardDragArea.transform.position;
                this.transform.parent = RewardDragArea.transform;
                GameManger_Master.CallEventInventoryUIToggle();
            }
        }

        public void GetRewardToPlayer()
        {
            this.transform.SetParent(RewardTarget.transform);

            if (RewardTarget == maskPivot)
            {
                maskIsCollected = true;
                isSuffocatted = false;
            }
            else
            {
                maskIsCollected = false;
                isSuffocatted = true;
            }

            this.transform.localPosition = Vector3.zero;
            this.transform.localRotation = Quaternion.identity;
            InventoryPanel.SetActive(false);
            Time.timeScale = 1;
        }


    }
}