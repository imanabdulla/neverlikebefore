using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run : MonoBehaviour
{
    public float speed;

    void Start()
    {
        //speed = 2f;
    }

    void Update()
    {
        transform.position = new Vector3(
            transform.position.x + speed * Mathf.Sign(transform.localScale.x),
            transform.position.y,
            transform.position.z);
    }
}
