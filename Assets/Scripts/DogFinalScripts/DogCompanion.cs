using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogCompanion : MonoBehaviour
{
    #region Fields

    Animator animator;
    public GameObject Player;
    public Collecting collectingScript;
    public ThrowingRocks throwingScript;
    public bool IsFoundSomeThing;
    private GameObject[] Rewards;

    public PathEditor pathToFollow;
    
    public int CurrentWay1PointID = 0;
    public float jumpSpeed = 50f;
    public float followSpeed = 5f;
    public float reachDistance = 1.0f;//distance bteween dog bivot and circle path pivot
    Vector3 lastPosition;
    Vector3 currentPosition;

    public GameObject mousePivot;

    bool isFollowingTheRock = false;
    bool IsFollowObj = false;
    bool isReachRock = false;
  



    [HideInInspector]
    public float distanceDogWayPoint;
    [HideInInspector]
    public float distanceDogPlayerInX;
   
    #endregion

    void Start()
    {
        animator = GetComponent<Animator>();

        Rewards = GameObject.FindGameObjectsWithTag("Rewards");


    }

    void Update()
    {
        Debug.Log(distanceDogWayPoint);

        if (Player.GetComponent<Animator>().GetInteger("AnimState") == 900)
        {


            Idel();

        }


        distanceDogWayPoint = pathToFollow.pathObjs[CurrentWay1PointID].position.x - this.GetComponent<Rigidbody2D>().transform.position.x;
          distanceDogPlayerInX = Player.transform.position.x - this.transform.position.x;
       
        if (Player.GetComponent<Animator>().GetInteger("AnimState") == 1 && distanceDogWayPoint > 13 && !throwingScript.isThrown && !IsFollowObj && (distanceDogPlayerInX < 50 || distanceDogPlayerInX > 0  || distanceDogPlayerInX > -50)  )
        {
        
                Debug.Log("laila");
                FollowMasah();

            }

           

            if (distanceDogWayPoint < 13 && !throwingScript.isThrown && !IsFollowObj)
            {
                Debug.Log("test");
                MoveOnPath();

            }






            if (throwingScript.isThrown)
            {

                FollowObj();

            }




            Physics2D.IgnoreCollision(this.GetComponent<Collider2D>(), Player.GetComponent<Collider2D>());

        
    }




    private void MoveOnPath()
    {



        //float distanceX = pathToFollow.pathObjs[CurrentWay1PointID].position.x - this.GetComponent<Rigidbody2D>().transform.position.x;
        //float distanceY = pathToFollow.pathObjs[CurrentWay1PointID].position.y - this.GetComponent<Rigidbody2D>().transform.position.y;

        //if (distanceX < 10 & distanceY < 10)
        //{
        this.GetComponent<Rigidbody2D>().gravityScale = 0;
        this.animator.SetInteger("DogAnimState", 2);//jump
        this.GetComponent<Rigidbody2D>().transform.position = Vector3.MoveTowards(this.GetComponent<Rigidbody2D>().transform.position, pathToFollow.pathObjs[CurrentWay1PointID].position, jumpSpeed * Time.deltaTime);
       


        if (distanceDogWayPoint <= reachDistance)
        {

            CurrentWay1PointID++;


        }

      
       


        if (CurrentWay1PointID == 16)
        {


            this.animator.SetInteger("DogAnimState", 7);//walk
            this.GetComponent<Rigidbody2D>().transform.position = Vector3.MoveTowards(this.GetComponent<Rigidbody2D>().transform.position, pathToFollow.pathObjs[17].position, followSpeed * Time.deltaTime);

        }

        if (CurrentWay1PointID == 34)
        {

            this.animator.SetInteger("DogAnimState", 7);//walk
            this.GetComponent<Rigidbody2D>().transform.position = Vector3.MoveTowards(this.GetComponent<Rigidbody2D>().transform.position, pathToFollow.pathObjs[35].position, followSpeed * Time.deltaTime);

        }

        if (CurrentWay1PointID == 36)
        {

            this.animator.SetInteger("DogAnimState", 7);//walk
            this.GetComponent<Rigidbody2D>().transform.position = Vector3.MoveTowards(this.GetComponent<Rigidbody2D>().transform.position, pathToFollow.pathObjs[37].position, followSpeed * Time.deltaTime);

        }



        if (pathToFollow.pathObjs[CurrentWay1PointID] == pathToFollow.pathObjs[51])
        {
            if (Player.GetComponent<Animator>().GetInteger("AnimState") == 1 && distanceDogWayPoint > 13 && !throwingScript.isThrown && !IsFollowObj && distanceDogPlayerInX < 50)
            {
                Debug.Log("laila");
                FollowMasah();

            }
        }




        if (CurrentWay1PointID == 62 || CurrentWay1PointID == 63 || CurrentWay1PointID == 64 || CurrentWay1PointID == 65)
        {
            this.animator.SetInteger("DogAnimState", 7);//walk
            this.GetComponent<Rigidbody2D>().transform.position = Vector3.MoveTowards(this.GetComponent<Rigidbody2D>().transform.position, pathToFollow.pathObjs[70].position, followSpeed * Time.deltaTime);

        }


        if (CurrentWay1PointID == 75 || CurrentWay1PointID == 76 || CurrentWay1PointID == 77)
        {

            this.animator.SetInteger("DogAnimState", 7);//walk
            this.GetComponent<Rigidbody2D>().transform.position = Vector3.MoveTowards(this.GetComponent<Rigidbody2D>().transform.position, pathToFollow.pathObjs[77].position, followSpeed * Time.deltaTime);

        }

        if (CurrentWay1PointID >= 89 && CurrentWay1PointID <= 94)
        {

            this.animator.SetInteger("DogAnimState", 7);//walk
            this.GetComponent<Rigidbody2D>().transform.position = Vector3.MoveTowards(this.GetComponent<Rigidbody2D>().transform.position, pathToFollow.pathObjs[98].position, followSpeed * Time.deltaTime);

        }


        if (CurrentWay1PointID >= 102 && CurrentWay1PointID <= 109)
        {

            this.animator.SetInteger("DogAnimState", 7);//walk
            this.GetComponent<Rigidbody2D>().transform.position = Vector3.MoveTowards(this.GetComponent<Rigidbody2D>().transform.position, pathToFollow.pathObjs[109].position, followSpeed * Time.deltaTime);

        }

        if (CurrentWay1PointID >= 109 && CurrentWay1PointID <= 117)
        {

            this.animator.SetInteger("DogAnimState", 7);//walk
            this.GetComponent<Rigidbody2D>().transform.position = Vector3.MoveTowards(this.GetComponent<Rigidbody2D>().transform.position, pathToFollow.pathObjs[117].position, followSpeed * Time.deltaTime);

        }

        if (CurrentWay1PointID >= 117 && CurrentWay1PointID <= 129)
        {

            this.animator.SetInteger("DogAnimState", 7);//walk
            this.GetComponent<Rigidbody2D>().transform.position = Vector3.MoveTowards(this.GetComponent<Rigidbody2D>().transform.position, pathToFollow.pathObjs[129].position, followSpeed * Time.deltaTime);

        }

    }

    void Idel()
    {


        this.animator.SetInteger("DogAnimState", 0);//idel


    }


    void FollowMasah()
    {

        this.animator.SetInteger("DogAnimState", 1);

        var position = this.transform.position;//current

        this.transform.position = Vector3.Lerp(this.transform.position, Player.transform.position, Time.deltaTime);

        position = this.transform.position;




        Debug.DrawLine(this.transform.position, Player.transform.position, Color.cyan);


        if ((Player.transform.position.x - this.transform.position.x) > 1 && this.transform.localScale.z == -1)
        {

            Vector3 DogScale = this.transform.localScale;
            DogScale.z *= -1;
            this.transform.localScale = DogScale;
        }
        else if ((Player.transform.position.x - this.transform.position.x < -1) && this.transform.localScale.z == 1)
        {

            Vector3 DogScale = this.transform.localScale;
            DogScale.z *= -1;
            this.transform.localScale = DogScale;
        }
    }





    void FollowObj()
    {
        IsFollowObj = true;
        this.animator.SetInteger("DogAnimState", 3);//followobj
        this.transform.position = Vector3.Lerp(this.transform.position, collectingScript.collectedRock.transform.position, Time.deltaTime);


        float dogRockDist = Vector3.Distance(this.transform.position, collectingScript.collectedRock.transform.position);


        if (dogRockDist <= 4)
        {
            Idel();
        }



        foreach (GameObject reward in Rewards)
        {
            float DogRewardDist = Vector3.Distance(this.transform.position, reward.transform.position);

            if (DogRewardDist <= 80 && dogRockDist <= 4)
            {



                this.transform.position = Vector3.Lerp(this.transform.position, reward.transform.position, Time.deltaTime);
                Debug.Log("lerptoreward");
                if (DogRewardDist <= 100)//40
                {
                    Debug.Log("find reward");


                    reward.transform.SetParent(mousePivot.transform);
                    reward.transform.localPosition = Vector3.zero;
                    reward.transform.localRotation = Quaternion.identity;
                    //  FollowMasah(); m4 3aref yrga3


                }


            }
            //else if (DogRewardDist >= 80 && dogRockDist <= 4)
            //    FollowMasah();m4 3aref yrga3



        }




    }










    //private void MoveItween()
    //{
    //    float t = 1f;
    //    float distance = Vector3.Distance(this.transform.position, iTween.PointOnPath(iTweenPath.GetPath("DogPath"), t));

    //    Debug.Log(distance);
    //    if (distance < 160)
    //    {
    //        Debug.Log("test");

    //       iTween.MoveTo(gameObject, iTween.Hash("path", iTweenPath.GetPath("DogPath"), "speed", 100f ,"islocal", true));
    //        // iTween.PutOnPath(this.gameObject, iTweenPath.GetPath("DogPath"),1f);

    //    }
    //}
}

