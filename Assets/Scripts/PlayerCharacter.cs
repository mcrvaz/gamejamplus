using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

	public float speed;
	public GameObject startingRail;

	private List<Rail> rails;
	private Rail currentRail;
	private int currentRailIndex;
	private GameObject nextWaypoint;
	private bool isChangingRail;

	void Awake() {
		this.rails = new List<Rail>(GameObject.FindObjectsOfType<Rail>());
		var startingRail = this.startingRail.GetComponent<Rail>();
		this.currentRailIndex = rails.FindIndex(e => startingRail);
		this.currentRail = rails[currentRailIndex];
	}

	void Start() {
		NextWaypoint();
	}

	void Update () {
		if (Input.GetButtonDown("Fire1") || Input.touchCount > 0) ChangeRail();
		Move();
	}

	void Move() {
		if (transform.position == nextWaypoint.transform.position) NextWaypoint();
		MoveToWaypoint();
	}

	void NextWaypoint(bool changingRail = false) {
		if (changingRail) {
			nextWaypoint = currentRail.GetNearestWaypoint(transform.position);
			nextWaypoint = currentRail.GetNextWaypoint();
		} else {
			nextWaypoint = currentRail.GetNextWaypoint();
		}
	}

	void MoveToWaypoint() {
		transform.position = Vector2.MoveTowards(
			transform.position,
			nextWaypoint.transform.position,
			Time.deltaTime * speed
		);
	}

	void ChangeRail() {
		int idx = currentRailIndex == 0 ? 1 : 0;
		currentRail = rails[idx];
		currentRailIndex = idx;
		NextWaypoint(true);
	}

}
