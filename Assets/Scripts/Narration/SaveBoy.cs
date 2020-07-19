using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class SaveBoy : MonoBehaviour
{
    public Flowchart flowchart;
    public Animator boyCryingAnimator;
    private Run boyRunning;
    private bool reachedGround = false;

    void Start()
    {
        boyRunning = boyCryingAnimator.GetComponent<Run>();
    }

    void Update()
    {
        if ( reachedGround && boyCryingAnimator.GetAnimatorTransitionInfo(0).normalizedTime >= 0.8)
        {
            boyRunning.enabled = true;
        }
    }


    void OnCollisionEnter2D(Collision2D collision2d)
    {
        if (!GameController.dialoguePresent)
        {
            if (collision2d.gameObject.tag.Equals("BoyCrying"))
            {

                boyCryingAnimator.SetTrigger("reachedGround");
                //boyCryingAnimator.SetTrigger("gotSaved");
                reachedGround = true;
                GameController.dialoguePresent = true;
            }

        }

    }
}
