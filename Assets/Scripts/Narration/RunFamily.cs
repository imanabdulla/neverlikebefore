using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunFamily : MonoBehaviour
{

    public Animator familyAnimator;
    private Run familyRunning;

    void Start()
    {
        familyRunning = familyAnimator.gameObject.GetComponent<Run>();
    }

    void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.tag.Equals("Player"))
        {
            familyRunning.enabled = true;
        }

    }
}