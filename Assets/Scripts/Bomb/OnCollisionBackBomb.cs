using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionBackBomb : MonoBehaviour {
    public GameObject Player;
    public GameObject Bomb;
    public int Count = 1;
    private int i = 0;
    public float distAfterPlayerInstBombInXAxis = 10;




    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {

            InstantiateBombs();

        }
    }




    private void InstantiateBombs()
    {
       

        while (i < Count)
        {

            Vector3 Dist = new Vector3(distAfterPlayerInstBombInXAxis, 0, 0);
            Vector3 BombStartingPoint = Player.transform.position + Dist;
            GameObject.Instantiate(Bomb, new Vector3(UnityEngine.Random.Range(BombStartingPoint.x, BombStartingPoint.x + 30), UnityEngine.Random.Range(30, 40), 9f), Quaternion.Euler(0, 0, 0));
            i++;

        }
    }
}
