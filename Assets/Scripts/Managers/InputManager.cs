using UnityEngine;

public static class InputManager {

	public static bool disableInput = false;

	public static bool isClicking() {
		if (disableInput) return false;
		return Input.GetMouseButtonDown(0);
	}

	public static bool isTouching() {
		if (disableInput) return false;
		return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
	}

}
