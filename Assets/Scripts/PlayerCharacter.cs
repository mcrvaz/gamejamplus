using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

	public float speed;
	public GameObject startingRail;

	private Rail currentRail;
	private GameObject nextWayPoint;

	void Awake() {
		this.currentRail = this.startingRail.GetComponent<Rail>();
	}

	void Start() {
		NextWaypoint();
		print(nextWayPoint.transform.position);
	}

	void Update () {
		Move();
	}

	void Move() {
		if (transform.position == nextWayPoint.transform.position) NextWaypoint();
		transform.position = Vector3.MoveTowards(transform.position, nextWayPoint.transform.position, Time.deltaTime * speed);
	}

	void NextWaypoint() {
		nextWayPoint = currentRail.GetNextWaypoint();
	}
}
