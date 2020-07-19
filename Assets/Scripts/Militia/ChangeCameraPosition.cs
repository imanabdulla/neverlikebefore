using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraPosition : MonoBehaviour {
    public GameObject mainCamera;
    private SetPositionBetweenPlayerAndCue playerAndCue;
    private FollowPlayer followPlayer;

    void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        playerAndCue = mainCamera.GetComponent<SetPositionBetweenPlayerAndCue>();
        followPlayer = mainCamera.GetComponent<FollowPlayer>();
    }

    void Start () {
        mainCamera.GetComponent<SetPositionBetweenPlayerAndCue>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
