using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum Buttons{
	Up, Down, Left, Right, Space, Ctrl, X, Q, Z
};

public enum Condition
{
	GreaterThan, LessThan
};

[System.Serializable]
public class InputAxisState {
	public string axisName;
	public float offValue;
	public Buttons button;
	public Condition condition;

	public bool Value {
		get {
			float val = Input.GetAxis (axisName);
			switch (condition) {
			case Condition.GreaterThan:
				return val > offValue;
			case Condition.LessThan:
				return val < offValue;
			}
			return false;
		}	
	}
}

// strong association relationship between InputAxisState and InputManager
// strong association relationship between InputState and InputManager
public class InputManager : MonoBehaviour {
	public InputAxisState[] inputAxesStates;
	public InputState inputState;

	private void Update () {
		foreach (var axisState in inputAxesStates) {
			inputState.SetButtonValue (axisState.button, axisState.Value);
		}
	}
}
