﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOff : MonoBehaviour {

  
	// Use this for initialization
	void Start () {
    
    }
	
	// Update is called once per frame
	void Update () {
    
    }
    private void OnMouseDown()
    {
         AudioListener.volume = 0f;
        
    }
    
}
