using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class StartFamilyDialogue : MonoBehaviour
{

    public Animator familyAnimator;
    public Flowchart flowchart;
    public GameObject masahGetsLost;
    private Run familyRunning;
    private bool movingRight = false;
    private Collider2D familyCollider;
    private bool startedTalking = false;

    [HideInInspector]
    public bool masahIsTalking = false;
    void Start()
    {
        familyRunning = familyAnimator.gameObject.GetComponent<Run>();
        familyCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (flowchart.GetBooleanVariable("masahAgreedToGoWithThem") ||
            flowchart.GetBooleanVariable("masahRefusedToGoWithThem"))
        {
            // family run
            familyAnimator.SetTrigger("dialogueEnded");
            familyRunning.enabled = true;
            GameController.dialoguePresent = false;
            //this.gameObject.SetActive(false);
            familyCollider.enabled = false;
            masahIsTalking = false;
            if (flowchart.GetBooleanVariable("masahAgreedToGoWithThem"))
            {
                if (!movingRight)
                {
                    familyAnimator.gameObject.transform.localScale = new Vector3(
                        familyAnimator.gameObject.transform.localScale.x * -1,
                        familyAnimator.gameObject.transform.localScale.y,
                        familyAnimator.gameObject.transform.localScale.z
                        );
                    familyRunning.speed = 0.25f;
                    movingRight = true;
                }
            }

            if (flowchart.GetBooleanVariable("masahRefusedToGoWithThem"))
            {
                masahGetsLost.SetActive(false);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider2d)
    {

        if (!GameController.dialoguePresent)
        {
            if (collider2d.tag.Equals("Player"))
            {
                Fungus.Flowchart.BroadcastFungusMessage("family approached");
                familyAnimator.SetTrigger("dialogueStarted");
                familyRunning.enabled = false;
                GameController.dialoguePresent = true;
                masahIsTalking = true;
            }
        }
    }

}
