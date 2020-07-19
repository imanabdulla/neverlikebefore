using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePlayerControls : MonoBehaviour
{
    public GameObject player;
    private bool dialoguePresent;
    private InputManager playerInputManager;
   

    void Start()
    {
        playerInputManager = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>();
    }

    void Update()
    {
        if (GameController.dialoguePresent)
        {
            GameController.inputEnabled = false;
        }
        else
        {
            GameController.inputEnabled = true;
        }
    }
}
