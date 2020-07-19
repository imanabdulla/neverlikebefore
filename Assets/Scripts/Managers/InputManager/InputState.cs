using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Direction {
	Left = -1, Right = 1
};


public class ButtonState {
	public bool value;
	public float holdTime;
}


// weak association relationship between InputState and ButtonState
public class InputState : MonoBehaviour {

	private Dictionary <Buttons, ButtonState> buttonStates = new Dictionary<Buttons, ButtonState> ();
	public Direction direction = Direction.Right;

	public void SetButtonValue(Buttons key, bool value) {

		if (!buttonStates.ContainsKey (key))
			buttonStates.Add (key, new ButtonState());

		ButtonState state = buttonStates [key];

		if (state.value && value) 
			state.holdTime += Time.deltaTime;
		else if (state.value && !value) 
			state.holdTime = 0;

		state.value = value;
	}


	public bool GetButtonValue(Buttons key) {
		if (buttonStates.ContainsKey (key))
			return buttonStates[key].value;
		else
			return false;
	}

	public float GetButtonHoldTime(Buttons key) {
		if (buttonStates.ContainsKey (key))
			return buttonStates[key].holdTime;
		else
			return 0;
	}

}
