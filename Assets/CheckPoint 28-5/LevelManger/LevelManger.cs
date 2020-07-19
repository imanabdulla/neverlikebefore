using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManger : MonoBehaviour {

    GameObject Player;
    public GameObject CurrentCheckPoint;
    public bool PlayerSpawn;
	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
      
	}
   public void RespawnPlayer()
    {
        
        Player.GetComponent<Transform>().position = CurrentCheckPoint.transform.position;
        PlayerSpawn = true;


    }
}
