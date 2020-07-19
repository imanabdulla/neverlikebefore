using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;
using UnityEngine.Audio;

public class StartOldManStory : MonoBehaviour
{
    public AudioMixerSnapshot inNarrationZone;
    public Flowchart flowchart;
    public Animator oldMan;
    private bool oldManWalking = false;
    private float m_TransitionIn;
    private bool musicPlaying = false;

    void Update()
    {
        if (flowchart.GetBooleanVariable("oldManFinished") || flowchart.GetBooleanVariable("masahSkippedStory"))
        {
            this.gameObject.SetActive(false);
            GameController.dialoguePresent = false;

            if (flowchart.GetBooleanVariable("oldManFinished"))
            {
                Fungus.Flowchart.BroadcastFungusMessage("camera fade out white");
                if (!musicPlaying)
                {
                    inNarrationZone.TransitionTo(m_TransitionIn);
                    musicPlaying = true;
                }
            }

        }
    }


    void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (!GameController.dialoguePresent)
        {
            if (collider2d.tag.Equals("Player"))
            {
                Fungus.Flowchart.BroadcastFungusMessage("start children story");
                GameController.dialoguePresent = true;
            }
        }
    }
}
