using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace S3
{

	public class WoodCollisionWithGround : MonoBehaviour 
	{
		public GameObject firePrefab;
        static int Counter = 0;
        private LevelManger levelManger;

        private void Start()
        {
            levelManger = FindObjectOfType<LevelManger>();
        }

        void OnTriggerEnter2D (Collider2D col2d)
		{
			if (col2d.gameObject.tag == "Obstacles"  || col2d.gameObject.tag == "Player" ) 
			{
				GameObject fireInstance = Instantiate (firePrefab, this.transform.position, Quaternion.identity);
                StartCoroutine("GameOver");
               /* if (col2d.gameObject.tag == "Player")
                    col2d.gameObject.GetComponent<Suffocating>().startDyingAnim = true;

                else if (col2d.gameObject.tag == "Obstacles")
                    StartCoroutine("GameOver");*/
			}
		}

        IEnumerator GameOver()
        {
           
            yield return new WaitForSeconds(0.5f);
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
}
