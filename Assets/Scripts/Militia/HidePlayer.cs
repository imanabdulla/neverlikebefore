using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidePlayer : MonoBehaviour
{

    public GameObject militia;

    void Start()
    {
        if (militia == null)
        {
            Debug.LogError("Militia is not found");

        }
    }

    void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.tag.Equals("Player"))
        {
            militia.GetComponent<SeePlayer>().playerHiding = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider2d)
    {
        if (collider2d.tag.Equals("Player"))
        {
            militia.GetComponent<SeePlayer>().playerHiding = false;
        }
    }
}
