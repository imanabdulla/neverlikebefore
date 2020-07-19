using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lerpweapon : MonoBehaviour
{
    public GameObject circle;
    public float speed = 0.1f;
    private ShootingTheBoy machineShooting;
    private bool GoingUp;

    // Use this for initialization

    private bool rotating = true;
    void Start()
    {
        GoingUp = false;
        StartCoroutine(SwitchRotate());
    }


    void Update()
    {

       
        if (!GoingUp )
        {
            
            transform.Rotate(new Vector3(0, 0,- 0.2f));

        }
       

        else
        { 
            
           
            transform.Rotate(new Vector3(0, 0, 0.2f));
            
        }

    }

   IEnumerator SwitchRotate()
    {
       
        yield return new WaitForSeconds(2);
        GoingUp = !GoingUp;
        StartCoroutine(SwitchRotate());

    }





    


}
