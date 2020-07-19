using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObject : MonoBehaviour
{
    public GameObject disabledObject;

    void OnTriggerEnter2D(Collider2D collider2d)
    {
        if (collider2d.tag.Equals("Player"))
        {
            if (!disabledObject.activeSelf)
            {
                disabledObject.SetActive(true);
            }
        }
    }
}
