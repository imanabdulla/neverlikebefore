using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutToBlack : MonoBehaviour
{
    [HideInInspector]
    public bool died = false;

    void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.tag.Equals("Player"))
        {
            Fungus.Flowchart.BroadcastFungusMessage("camera fade out black");
            died = true;
        }
    }
}
