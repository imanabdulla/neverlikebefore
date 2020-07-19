using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupboardSmashing : MonoBehaviour
{
    public AudioClip crashSound;
    private Animator animator;
    private AudioSource source;

    private void Start()
    {
        animator = this.GetComponent<Animator>();
        source = this.GetComponent<AudioSource>();
        animator.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D col2d)
    {
        if (col2d.gameObject.tag == "Obstacles")
        {
            animator.enabled = true;
            this.GetComponent<BoxCollider2D>().enabled = false;
            col2d.gameObject.layer = LayerMask.NameToLayer("NonCollidedObstacles");
            col2d.gameObject.GetComponent<Rigidbody2D>().mass = 1000;
            source.PlayOneShot(crashSound, 0.5f);
        }
    }
}
