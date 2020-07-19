using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilitiaStateManager : MonoBehaviour
{

    // for the Patrol script, patrol points for the militia to patrol on.
    public Transform[] patrolPoints;

    // for Chase script
    public GameObject player;
    public LayerMask layer;

    private Rigidbody2D body2d;
    [SerializeField]
    public MilitiaState militiaState;
    private SeePlayer seePlayer;

    private GameObject mainCamera;
    private bool chasing = false;
    private bool patroling = false;
    private bool alerting = false;
    private Chase chaseState;
    private float alertTimer;
    private Animator animator;
    private bool cuePresent = false;

    public bool isGrounded;
    void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
        seePlayer = GetComponent<SeePlayer>();
        animator = GetComponent<Animator>();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Start()
    {
        SetState(new Patrol(patrolPoints, body2d, animator));
        patroling = true;
    }

    void Update()
    {
        isGrounded = militiaState.isGrounded;
        /*
         * check if the player is in the militia sight.
         */
        if (seePlayer.playerInSight)
        {

            // put camera between player and cue.
            if (!cuePresent)
            {
                mainCamera.GetComponent<SetPositionBetweenPlayerAndCue>().Cue = this.gameObject;
                mainCamera.GetComponent<SetPositionBetweenPlayerAndCue>().enabled = true;
                mainCamera.GetComponent<FollowPlayer>().enabled = false;
                cuePresent = true;
            }

            /*
             * if the militia is in the patrol state or in the alert state. 
             */
            if (patroling || alerting)
            {
                /*
                 * change militia state to chase state. 
                 */
                SetState(new Chase(body2d, player, layer, animator));
                patroling = false;
                chasing = true;
                alerting = false;
            }
            else
            {
                /*
                 * continue chasing. 
                 */
            }
        }

        /*
         * if the player is not in the militia sight,
         * militia is either in chase state or in alert state. 
         */
        else
        {
            /*
             * check if the militia is in chase state.
             */
            if (chasing)
            {
                /*
                 * change militia state to alert state.
                 */
                SetState(new Alert(patrolPoints, body2d, animator, this));
                patroling = false;
                chasing = false;
                alerting = true;
                /*
                 * start timer. 
                 */
                alertTimer = 5f;
            }
            else if (alerting)
            {
                /*
                 * check if alert timer completed: 30 seconds elapsed. 
                 */
                if (alertTimer < 0)
                {
                    /*
                     * change militia state to patrol state.
                     */
                    SetState(new Patrol(patrolPoints, body2d, animator));
                    patroling = true;
                    chasing = false;
                    alerting = false;

                }
                else
                {
                    /*
                     * continue alerting. 
                     */

                    /*
                     * subtract from timer.
                     */ 
                    alertTimer -= Time.deltaTime;
                    Debug.Log(alertTimer.ToString());
                }
            }
            else
            {
                /*
                 * continue patroling. 
                 */
                patroling = true;
                chasing = false;
                alerting = false;


                // if cue is present set camera to follow player and remove cue.
                if (cuePresent)
                {
                    mainCamera.GetComponent<SetPositionBetweenPlayerAndCue>().Cue = null;
                    mainCamera.GetComponent<SetPositionBetweenPlayerAndCue>().enabled = false;
                    mainCamera.GetComponent<FollowPlayer>().enabled = true;
                    cuePresent = false;
                }
            }
        }
        
        militiaState.Handle();
    }

    public void SetState(MilitiaState state)
    {
        militiaState = state;
    }

}
