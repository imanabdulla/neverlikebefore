using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    private LevelManger levelManger;

	// Use this for initialization
	void Start () {
        levelManger = FindObjectOfType<LevelManger>();
	}
	
	// Update is called once per frame
	void Update () {
       
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelManger.CurrentCheckPoint = gameObject;
    }
}
