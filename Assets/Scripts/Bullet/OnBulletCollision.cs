using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public class OnBulletCollision : MonoBehaviour
    {
       
        public GameObject GameManger;
        public GameObject shrapnel;
        LevelManger levelManger;
        static int Counter = 0;

        private void Start()
        {
            levelManger = FindObjectOfType<LevelManger>();
        }
       

        void OnCollisionEnter2D(Collision2D col)
        {

            if (col.gameObject.tag == "Ground")
            {

                Destroy(this.gameObject);

                /*
                 * Instantiate fire from particle system. 
                 */
                Instantiate(shrapnel, new Vector3 (transform.position.x,transform.position.y+20,0), Quaternion.identity);
            }

            

            if (col.gameObject.tag == "Player")
            {
                Destroy(this.gameObject);
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
                    GameManger_Master.CallEventGameOverBullet();
                    Counter = 0;
                }
            }
        }
    }
}
