using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour {

    public GameObject SettingsPannel;
    public GameObject Menu;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void TurnOnSeetingPanel()
    {

        if (SettingsPannel != null)
        {

            SettingsPannel.SetActive(!SettingsPannel.activeSelf);
            Menu.SetActive(false);
           
        }
    }
}
