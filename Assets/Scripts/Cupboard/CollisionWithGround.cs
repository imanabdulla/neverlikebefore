using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionWithGround : MonoBehaviour {
    public bool isOnAir;
    private void OnTriggerEnter2D(Collider2D coll2d)
    {
        if (coll2d.gameObject.tag == "Obstacles")
            isOnAir = true;
    }
}
