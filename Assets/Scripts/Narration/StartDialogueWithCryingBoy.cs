using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class StartDialogueWithCryingBoy : MonoBehaviour
{
    public Animator boyCryingAnimator;
    public Flowchart flowchart;
    private Run boyRunning;

    void Update()
    {
        if (flowchart.GetBooleanVariable("masahHelpedBoy")
            || flowchart.GetBooleanVariable("masahRefusedToHelpBoy"))
        {
            GameController.dialoguePresent = false;
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (!GameController.dialoguePresent)
        {
            if (collider2d.tag.Equals("Player"))
            {
                Fungus.Flowchart.BroadcastFungusMessage("the young boy is crying");
                GameController.dialoguePresent = true;
            }
        }
    }
}
