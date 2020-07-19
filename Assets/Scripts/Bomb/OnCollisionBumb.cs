using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public class OnCollisionBumb : MonoBehaviour
    {
        public GameObject Player;
        public GameObject BombPrefab;
        public int Count = 1;
        private int i = 0;
        [HideInInspector]
        public bool IsBombInst = false;
        public float distAfterPlayerInstBombInXAxis = 5;
        public LevelManger levelManger;


        private void Start()
        {
            levelManger = FindObjectOfType<LevelManger>();

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.gameObject.tag == "Player")
            {

                InstantiateBombs();

            }
        }




        private void InstantiateBombs()
        {
            IsBombInst = true;


            while (i < Count)
            {
                Vector3 Dist = new Vector3(distAfterPlayerInstBombInXAxis, 0, 0);
                Vector3 BombStartingPoint = Player.transform.position - Dist;
                Vector3 BombEndingPoint = Player.transform.position + Dist;

                GameObject.Instantiate(BombPrefab,
                   new Vector3(UnityEngine.Random.Range(BombStartingPoint.x, BombEndingPoint.x),
                   UnityEngine.Random.Range(30, 40), -40f), Quaternion.Euler(0, 0, 0));

                GameObject.Instantiate(BombPrefab,
                    new Vector3(UnityEngine.Random.Range(BombStartingPoint.x, BombEndingPoint.x),
                    UnityEngine.Random.Range(30, 40), -40f), Quaternion.Euler(0, 0, 0));
                i++;

            }

            if (levelManger.PlayerSpawn)
            {
                Debug.Log(levelManger.PlayerSpawn);
                i = 0;
                levelManger.PlayerSpawn = false;

            }


        }
    }
}
