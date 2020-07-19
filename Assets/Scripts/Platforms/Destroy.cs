using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

    private Collider2D extent;

    void Start()
    {
        extent = GetComponent<Collider2D>();
    }

	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collider2d)
    {

        if (collider2d.gameObject.tag.Equals("PlatformDestroyer"))
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
