using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class StartMasahDialogWhenGettingLost : MonoBehaviour
{
    public Animator familyAnimator;
    public Flowchart flowchart;
    private Run familyRunning;
    private Shake shakeCam;
    private Collider2D gettingLostCollider;
    private bool camIsShaking = false;

    void Start()
    {
        familyRunning = familyAnimator.gameObject.GetComponent<Run>();
        shakeCam = GetComponent<Shake>();
        gettingLostCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        if (flowchart.GetBooleanVariable("masahLost"))
        {
            //this.gameObject.SetActive(false);
            //gettingLostCollider.enabled = false;
            GameController.dialoguePresent = false;
            if (camIsShaking)
            {
                shakeCam.enabled = false;
                camIsShaking = false;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (!GameController.dialoguePresent)
        {
            if (collider2d.tag.Equals("Player"))
            {

                Fungus.Flowchart.BroadcastFungusMessage("masah gets lost");
                shakeCam.enabled = true;
                camIsShaking = true;

                GameController.dialoguePresent = true;

                // dim family color

                // family runs in left
                familyAnimator.gameObject.transform.localScale = new Vector3(
                            familyAnimator.gameObject.transform.localScale.x * -1,
                            familyAnimator.gameObject.transform.localScale.y,
                            familyAnimator.gameObject.transform.localScale.z
                            );

                gettingLostCollider.enabled = false;

                // change family speed to higher
                // familyRunning.speed = 0.5f;
            }

        }

    }

    //void OnTriggerExit2D(Collider2D col)
    //{
    //    if (col.tag.Equals("Player"))
    //    {
    //        shakeCam.enabled = false;
    //    }
    //}
}
