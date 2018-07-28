using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject toFollow;
	public float followSpeed;

	void Update () {
		var newPosition = new Vector3(
			toFollow.transform.position.x,
			transform.position.y,
			transform.position.z
		);
		transform.position = Vector3.Slerp(
			transform.position,
			newPosition,
			followSpeed * Time.deltaTime
		);
	}
}
