using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : PlayerBehaviors {

    void Update () {
		bool right = inputState.GetButtonValue (buttons[0]);
		bool left = inputState.GetButtonValue (buttons[1]);

		if (right) 
			inputState.direction = Direction.Right;
		else if (left) 
			inputState.direction = Direction.Left;

		this.transform.localScale = new Vector3 (this.transform.localScale.x,
			this.transform.localScale.y, Mathf.Abs(this.transform.localScale.z) * (float)inputState.direction);
	}
}
