using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackBomb : MonoBehaviour {

    public float bombSpeed = 50f;
    public event System.Action explode;
    public AudioClip explosionSound;
    private Rigidbody2D rigidBody;
    private GameObject Explode;
    public GameObject explosionFire;
    public float radius;
    public float force;

    


  
    public void OnExplode()
    {
        /*
         * Instantiate fire from particle system. 
         */
        Instantiate(explosionFire, transform.position, Quaternion.identity);

        /*
         * Affect all rigidbodies around the explosion.
         */
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (var c in colliders)
        {
            if (c.GetComponent<Rigidbody>() == null)
            {
                continue;
            }
            else
            {
                c.GetComponent<Rigidbody>().AddExplosionForce(force, transform.position, radius,
                    0.5f, ForceMode.Impulse);
            }
        }

        if (explode != null)
        {
            explode.Invoke();
        }
    }


    void FixedUpdate()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = Vector3.down * bombSpeed;

    }




    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "BackGround")
        {

            Destroy(this.gameObject);
            Destroy(Explode, 2);
            OnExplode();
        }


    }

}
