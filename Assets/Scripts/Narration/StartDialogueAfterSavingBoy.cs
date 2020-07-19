using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class StartDialogueAfterSavingBoy : MonoBehaviour
{
    public Animator boyCryingAnimator;
    public Flowchart flowchart;
    private JumpBoy boyJump;
    private bool boyIsJumping = false;
    private Run boyRunning;

    void Start()
    {
        boyJump = boyCryingAnimator.GetComponent<JumpBoy>();
        boyRunning = boyCryingAnimator.GetComponent<Run>();

    }

    void Update()
    {
        if (flowchart.GetBooleanVariable("boySaved"))
        {
            //boyCryingAnimator.SetTrigger("gotSaved");
            //boyRunning.enabled = true;
            GameController.dialoguePresent = false;
            this.gameObject.SetActive(false);
        }
    }


    void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (!boyIsJumping)
        {
            if (collider2d.tag.Equals("PlatformSaveBoy"))
            {
                boyCryingAnimator.SetTrigger("platformIsUnderHim");
                // crying boy will jump
                boyJump.enabled = true;

                // crying boy will thank masah
                Fungus.Flowchart.BroadcastFungusMessage("saved the boy");
                boyIsJumping = true;
            }
        }
    }
}
