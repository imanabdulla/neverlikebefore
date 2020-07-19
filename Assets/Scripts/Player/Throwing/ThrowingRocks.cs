using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class ThrowingRocks : PlayerBehaviors 
{
	#region Fields
	[HideInInspector]
	public bool startThrowingAnim, isPressed, isThrown;
	public Slider sliderScript;
	public GameObject slider;

	private GameObject[] smallRocks;

	private float keyHoldTime, dx, dy, multiplier = 5, time1, time2, posX, posY;
	private int i = 0;
	private Vector2 initialVelocityOfCollectedRock, velocityOfCollectedRock;
	private Collecting collectingScript;
	#endregion

	protected override void Awake () 
	{
		base.Awake ();
		collectingScript = this.GetComponent<Collecting> ();
		smallRocks = GameObject.FindGameObjectsWithTag ("SmallRocks");
	}


	private void Start () 
	{
		slider.SetActive(false);
        sliderScript.minValue = 1  * multiplier;
		sliderScript.maxValue = 5 * multiplier;
		startThrowingAnim = false;
		keyHoldTime = 0; time1 = 0; time2 = 0;
	}


	private void Update () 
	{
		bool z = inputState.GetButtonValue (buttons[0]);

		//When the rock is being thrown
		if (z && collectingScript.rockIsCollected) 
		{
			isPressed = true;
			isThrown = false;
			collectingScript.collectedRock.GetComponent<RockCollisionOnGround> ().isDropped = false;
			CalculateInitialVelocity ();
		}

		//After the rock has been thrown
		else if (!z && isPressed) 
		{
			startThrowingAnim = true;
			if (collectingScript.collectedRock.GetComponent<RockCollisionOnGround> ().isDropped) 
			{
				startThrowingAnim = false;
				time1 = 0;
				time2 = 0;
				isPressed = false;
				isThrown  = true;

				slider.SetActive (false);
				sliderScript.value = 0;
			}
		}
	}


	private void CalculateInitialVelocity () 
	{
		slider.SetActive (true);

		//calculate key hold time
		keyHoldTime = Mathf.Clamp(inputState.GetButtonHoldTime (buttons[0]), 1, 5);

		sliderScript.value = keyHoldTime * multiplier;

		//calculate initialVelocity of throwing
		initialVelocityOfCollectedRock = new Vector2 (multiplier*keyHoldTime, multiplier*keyHoldTime);

		//calculate start position of of TrajectoryPoint
		posX = collectingScript.collectedRock.transform.position.x;
		posY = collectingScript.collectedRock.transform.position.y;
	}


	public void ThrowTheRock () 
	{
		collectingScript.collectedRock.gameObject.transform.SetParent (null);
		collectingScript.collectedRock.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

		//calculate velocity every frame
		velocityOfCollectedRock.x = initialVelocityOfCollectedRock.x;
		velocityOfCollectedRock.y = initialVelocityOfCollectedRock.y - (9.81f * time2);

		collectingScript.collectedRock.GetComponent<Rigidbody2D>().velocity = new Vector2 (velocityOfCollectedRock.x, velocityOfCollectedRock.y);
		time2 += 0.02f;
	}
}
