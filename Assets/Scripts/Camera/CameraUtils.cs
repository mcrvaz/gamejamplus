using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CameraUtils {

	public static IEnumerator CameraZoom(Camera camera, float fov) {
		while (camera.fieldOfView > fov) {
			camera.fieldOfView = Mathf.Lerp(camera.fieldOfView, fov, 2 * Time.deltaTime);
			yield return null;
		}
	}

	public static IEnumerator FocusOnObject(Camera camera, GameObject go) {
		while (camera.transform.position != go.transform.position) {
			var newPosition = new Vector3(
				go.transform.position.x,
				go.transform.position.y,
				camera.transform.position.z
			);
			camera.transform.position = Vector3.Lerp(camera.transform.position, newPosition, 2 * Time.deltaTime);
			yield return null;
		}
	}

}
