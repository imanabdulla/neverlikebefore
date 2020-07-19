using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class ReadDialogue : MonoBehaviour
{
    public Flowchart flowchart;

    void Start()
    {

    }
    void Update()
    {
        if (flowchart.GetBooleanVariable("masahConfused"))
        {
            GameController.dialoguePresent = true;
        }
        else
        {
            GameController.dialoguePresent = false;
            this.gameObject.SetActive(false);
        }
    }
}