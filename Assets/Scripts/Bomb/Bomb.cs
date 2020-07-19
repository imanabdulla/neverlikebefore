using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace S3
{
    public class Bomb : MonoBehaviour
    {
        public float bombSpeed = 0.01f;
        public event System.Action explode;
        public GameObject ShadowAnim;
		public GameObject player;
        public AudioClip explosionSound;
        public AudioClip BompDroppingSound;
        public GameObject GameManger;
        public GameObject explosionFire;
        public float radius;
        public float force;
        [HideInInspector]
        public bool bombIsDropped;
        private GameObject colliderBombCue;
        private List<GameObject> bombCue;
		private LevelManger levelManger;
        private GameObject mainCamera;
		private Collectables collectablesScript;
        private Rigidbody2D rigidBody;
        private GameObject Shadow;
        private GameObject Explode;
        [HideInInspector]
        public static bool isMaskRemoved = false;
        static int Counter = 0;

        private void Awake()
        {
            colliderBombCue = GameObject.FindGameObjectWithTag("ColliderBombCamEffect");
			collectablesScript = GameObject.FindGameObjectWithTag ("Mask").GetComponent<Collectables> ();
            SetPositionBetweenPlayerBombCue.bombsCue.Add(this.gameObject);
            AudioSource.PlayClipAtPoint(BompDroppingSound, transform.position, 0.1f);
            InstatiateShadowBomb();
        }

        private void Start()
        {
            levelManger = FindObjectOfType<LevelManger>();
            bombIsDropped = false;
        }

        private void Update()
        {
            if (collectablesScript.maskIsCollected && bombIsDropped)
            {
                
                collectablesScript.gameObject.transform.SetParent(null);
                isMaskRemoved = true;
                if (collectablesScript.gameObject.GetComponent<Rigidbody2D>() == null)
                {
                    collectablesScript.gameObject.AddComponent<Rigidbody2D>();
                }
                Destroy(collectablesScript.gameObject, 1.5f);
            }
        }

        private void FixedUpdate()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            rigidBody.velocity = Vector3.down * bombSpeed;

        }

        public void InstatiateShadowBomb()
        {
            Shadow = Instantiate(ShadowAnim, new Vector3(transform.position.x, -50f, transform.position.z), Quaternion.identity);
        }

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

        public void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.tag == "Ground")
            {
                if (collectablesScript.maskIsCollected)
                {
                    bombIsDropped = true;
                    Invoke("DestroyBomb", 0.1f);
                }
                else
                {
                    bombIsDropped = false;
                    Invoke("DestroyBomb", 0);
                }

               
            }

            if (col.gameObject.tag == "Player")
            {

                if (Counter < 1)
                {

                    /*
                     * Start player die animation. 
                     */

                    levelManger.RespawnPlayer();

                    Counter++;

                }
                else
                {
                    GameManger_Master.CallEventGameOver();
                    Counter = 0;
                }
            }
        }

        private void DestroyBomb()
        {
            Destroy(this.gameObject);
            SetPositionBetweenPlayerBombCue.bombsCue.Remove(this.gameObject);
            Destroy(Explode, 2);
            Destroy(Shadow);
            OnExplode();
        }
    }
}



