using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoy : MonoBehaviour
{
    private float yOffset = 0.2f;

    void Update()
    {
        transform.position = new Vector3(transform.position.x,
            transform.position.y - yOffset,
            transform.position.z);
    }
}
