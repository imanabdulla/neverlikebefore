using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public class Suffocating : PlayerBehaviors
    {
        private RunningAndSneaking runningScript;
        private Collectables collectablesScript;
        private float minSpeed;
        private float maxSpeed;
        public bool startSuffocationAnim;
        public bool startDyingAnim;


        private void Start()
        {
            runningScript = this.GetComponent<RunningAndSneaking>();
            collectablesScript = GameObject.FindGameObjectWithTag("Mask").GetComponent<Collectables>();
            minSpeed = runningScript.speed * runningScript.fraction;
            maxSpeed = runningScript.speed;
        }

        private void Update()
        {

        }
        private void OnTriggerEnter2D(Collider2D col2d)
        {
            if (col2d.gameObject.tag == "Smoke" && collectablesScript.isSuffocatted)
            {
                runningScript.speed = minSpeed;
                startSuffocationAnim = true;
                Invoke("PlayerDying", 7);
            }
            if (!collectablesScript.isSuffocatted && col2d.gameObject.tag == "Smoke")
            {
                runningScript.speed = maxSpeed;
                startSuffocationAnim = false;
                CancelInvoke();
            }
        }


        private void OnTriggerExit2D(Collider2D col2d)
        {
            if (col2d.gameObject.tag == "Smoke")
            {
                CancelInvoke();
                runningScript.speed = maxSpeed;
                startSuffocationAnim = false;
                startDyingAnim = false;
            }
        }


        public void PlayerDying()
        {
            startDyingAnim = true;
        }
    }
}
