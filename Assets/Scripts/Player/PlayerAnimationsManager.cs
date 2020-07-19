using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace S3
{
    public class PlayerAnimationsManager : PlayerBehaviors
    {
        private Animator anim;
        private Collecting collecting;
        private ThrowingRocks throwingRocks;
        private Suffocating suffocating;
        private DuckingAndCrawling ducking;
        private Jumping jumpScript;
        private LevelManger levelManger;
        public StartFamilyDialogue startFamilyDialogue;
        public FadeOutToBlack fadeOutBlack;
        [HideInInspector]
        public bool isDead = false, isLanding = false;
        static int atakState = Animator.StringToHash("wakingUp");
        static int Counter = 0;
        protected override void Awake()
        {
            base.Awake();
            isDead = false;
            anim = this.GetComponent<Animator>();
            jumpScript = this.GetComponent<Jumping>();
            ducking = this.GetComponent<DuckingAndCrawling>();
            collecting = this.GetComponent<Collecting>();
            throwingRocks = this.GetComponent<ThrowingRocks>();
            suffocating = this.GetComponent<Suffocating>();
            levelManger = FindObjectOfType<LevelManger>();

        }


        private void Update()
        {
            if (!isDead)
            {


                //idle
                if (collisionState.isStanding && !anim.GetAnimatorTransitionInfo(0).IsName("wakingUp")
                    && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.9f)
                {
                    ChangeAnimationState(900);
                }

                //running
                if (absVelX > 0.0000001)
                {
                    ChangeAnimationState(1);
                }

                //sneaking
                if (inputState.GetButtonValue(buttons[0]))
                {
                    ChangeAnimationState(2);
                }

                //jumping
                if (jumpScript.startJumpingAnimation)
                {

                    ChangeAnimationState(3);
                    if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jumping3D") && anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.8f && collisionState.isStanding)
                    {
                        ChangeAnimationState(1000);
                        isLanding = true;
                        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.7f)
                        {
                            isLanding = false;
                            jumpScript.startJumpingAnimation = false;
                        }
                    }
                }

                //pushing
                if (inputState.GetButtonValue(buttons[2]))
                {
                    ChangeAnimationState(7);
                }

                //collecting
                if (collecting.startCollectingAnim)
                {
                    ChangeAnimationState(9);
                    if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                    {
                        collecting.startCollectingAnim = false;
                    }
                }

                //throwing
                if (throwingRocks.startThrowingAnim)
                {
                    ChangeAnimationState(10);
                    if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                        throwingRocks.startThrowingAnim = false;
                }


                //suffocating
                if (suffocating.startSuffocationAnim)
                {
                    if (absVelX > 1)
                        ChangeAnimationState(2);
                    else
                        ChangeAnimationState(11);
                }

               

                //ducking
                if (ducking.isDucking || Bomb.isMaskRemoved)
                {
                    ChangeAnimationState(5);
                    if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
                    {
                        Invoke("RemoveMask", 3f);
                    }
                }

                //crawling
                if (ducking.isDucking && absVelX > 0)
                {
                    ChangeAnimationState(6);
                }

                // talking
                if (startFamilyDialogue.masahIsTalking)
                {
                    ChangeAnimationState(13);
                }

                //dying
                if (suffocating.startDyingAnim || fadeOutBlack.died)
                {
                    ChangeAnimationState(12);
                    if(Counter == 0)
                        StartCoroutine("RespawnPlayer");
                    if(Counter == 1)
                        StartCoroutine("GameOver");
                }

            }
        }

        IEnumerator RespawnPlayer()
        {
            yield return new WaitForSeconds(3);
            suffocating.startDyingAnim = false;
            levelManger.RespawnPlayer();
            Counter = 1;
        }

        IEnumerator GameOver()
        {
            yield return new WaitForSeconds(3);
            //suffocating.startDyingAnim = false;
            GameManger_Master.CallGameOverSuffocating();
            isDead = true;
        }

        private void ChangeAnimationState(int animState)
        {
            anim.SetInteger("AnimState", animState);
        }

        private void RemoveMask()
        {
            Bomb.isMaskRemoved = false;
        }
    }
}