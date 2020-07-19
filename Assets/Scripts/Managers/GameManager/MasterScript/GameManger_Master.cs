 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public  class GameManger_Master  :MonoBehaviour
    {
        public delegate void GameMangerEventHandler();
        public static event GameMangerEventHandler MenuToggleEvent;
        public static event GameMangerEventHandler InventoryUIToggleEvent;
        public static event GameMangerEventHandler RestartToggleEvent;
        public static event GameMangerEventHandler GotomenuSceneEvent;
        public static event GameMangerEventHandler GameOverEvent;
        public static event GameMangerEventHandler GameExitEvent;
        public static event GameMangerEventHandler GameOverBulletEvent;
        public static event GameMangerEventHandler GameOverSuffocatingEvent;
        public static event GameMangerEventHandler GameOverCaughtByMilitiaEvent;
        public static event GameMangerEventHandler GameOverWoodBomb;
        public static event GameMangerEventHandler HelpMenuEvent;



        public static bool isGameOver;
        public static bool isInventory;
       

        //public static GameManger_Master Instance
        //{
        //    get
        //    {
        //        if (MyInstance == null)
        //        {
        //            return new GameManger_Master();
        //        }
        //        else
        //        {
        //            return MyInstance;
        //        }
        //    }    
        //}

        //private GameManger_Master() { }


		//event firing/publishing
        public static void CallEventMenuToggle()
        {
            
            if(MenuToggleEvent != null)
            {
               
                MenuToggleEvent();
            }
        }

        public static void CallEventInventoryUIToggle()
        {
            if(InventoryUIToggleEvent != null)
            {
               
                InventoryUIToggleEvent();
            }
        }

        public static void CallEventRestartToggle()
        {
            if(RestartToggleEvent != null)
            {
                Debug.Log("lll");
                RestartToggleEvent.Invoke();
            }
        }

        public static void CallEventGotoMenuSceneToggle()
        {
            if(GotomenuSceneEvent != null)
            {
                CallEventGotoMenuSceneToggle();
            }
        }
        public static void CallEventGameOver()
        {
            if(GameOverEvent != null)
            {
                isGameOver = true;
                GameOverEvent();
            }
        }


        public static void CallEventGameOverBullet()
        {
            isGameOver = true;

            if (GameOverBulletEvent != null)
            {
                GameOverBulletEvent();
            }
        }


        public static void CallGameExit()
        {
            if (GameExitEvent != null)
            {
                GameExitEvent();
            }
        }

        public static void CallGameOverSuffocating()
        {
            if (GameOverSuffocatingEvent != null)
            {
                GameOverSuffocatingEvent();
            }
        }

         public static void CallGameOverCaughtByMilitia()
        {
            if (GameOverCaughtByMilitiaEvent != null)
            {
               GameOverCaughtByMilitiaEvent();
            }
        }

        public static void CallGameOverWoodBomb()
        {
            if (GameOverWoodBomb != null)
            {
                GameOverWoodBomb();
            }
        }


        public void CallHelpMenu()
        {
            if (HelpMenuEvent != null)
            {
                HelpMenuEvent();
            }
        }


    }
}

