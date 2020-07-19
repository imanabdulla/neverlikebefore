using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collecting : PlayerBehaviors 
{
	#region Fields
	[HideInInspector]
	public bool startCollectingAnim, rockIsCollected;
	[HideInInspector]
	public GameObject collectedRock;

	private GameObject[] collectableRocks;
	private int counter = 0, flag = 0;
	#endregion


	private void Start()
	{
		collectedRock = null;
        startCollectingAnim = false;
	}


	private void Update() 
	{

        bool q = Input.GetKeyDown (KeyCode.Q);

		if (q) 
		{
			if (!rockIsCollected)
				startCollectingAnim = true;
			else if (rockIsCollected) 
				UncollectRocks ();
		} 
	}



	//Function will be excuted by an an event when the collecting animation runs
	public void CollectRocks () 
	{
		
		collectableRocks = GameObject.FindGameObjectsWithTag ("SmallRocks");

		foreach (var rock in collectableRocks) 
		{
			if (rock.GetComponent<HoldingRockOnHand>().canCollect) 
			{
				collectedRock = rock;
				collectedRock.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Kinematic;

				rock.transform.SetParent (rock.GetComponent<HoldingRockOnHand>().pivotCollider.gameObject.transform);	
				rock.transform.localPosition = Vector3.zero;
				rock.transform.localRotation = Quaternion.identity;

				rockIsCollected = true;
				collectedRock.GetComponent<RockCollisionOnGround> ().isDropped = false;
			}
		}

	}


	private void UncollectRocks () 
	{
		collectedRock.GetComponent<Rigidbody2D> ().bodyType = RigidbodyType2D.Dynamic;
		collectedRock.GetComponent<HoldingRockOnHand> ().canCollect = false;
		collectedRock.transform.SetParent (null);

		rockIsCollected = false;
	}
}
