using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    public GameObject bullet;
    public float bulletSpeed = 100;
    public AudioClip bulletSound;

    private GameObject bulletInstance;
    private Rigidbody2D bulletRb;

    private ShootingTheBoy shootingTheBoy;
    GameObject Ground;
    public float bulletRotation_X;
    public float bulletRotation_Y;
    public float bulletRotation_Z;






    void Start()
    {

        shootingTheBoy = GameObject.FindGameObjectWithTag("MachineShooting").GetComponent<ShootingTheBoy>();
        InvokeRepeating("shot", 1f, 1f);//after 1 sec it will call 1 time
        Ground = GameObject.FindGameObjectWithTag("Ground"); 

    }

    public void shot()
    {
        float xDir = this.transform.position.x;
        float yDir = this.transform.position.y;
        // Vector3 spawnVector = new Vector2(xDir, yDir);
        if (shootingTheBoy.startMachineShooting)
        {
            bulletInstance = Instantiate(bullet, this.transform.position, Quaternion.Euler(bulletRotation_X, bulletRotation_Y, bulletRotation_Z));
            bulletInstance.AddComponent<Rigidbody2D>();
            bulletRb = bulletInstance.GetComponent<Rigidbody2D>();
            Vector2 direction = this.transform.right;
            bulletRb.AddForce(direction.normalized * bulletSpeed, ForceMode2D.Impulse);
            //  bulletIn
            //bulletInstance.transform.rotation = Quaternion.LookRotation(direction);
            AudioSource.PlayClipAtPoint(bulletSound, bulletInstance.transform.position);
            //Physics2D.IgnoreCollision(bulletInstance.GetComponent<Collider>(), bulletInstance.GetComponent<Collider>());
            // Destroy(bulletInstance, 1f);
        }
    }


}