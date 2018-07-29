using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

	[Range(0, 20)]
	public float speed;
	public GameObject startingRail;

	private List<Rail> rails;
	private Rail currentRail;
	private int currentRailIndex;
	private GameObject nextWaypoint;
	private bool isChangingRail;
	private PlayerAnimatorController animController;

	void Awake() {
		this.rails = new List<Rail>(GameObject.FindObjectsOfType<Rail>());
		this.currentRailIndex = 1;
		this.currentRail = rails[currentRailIndex];
		this.animController = GetComponent<PlayerAnimatorController>();
	}

	void Start() {
		NextWaypoint();
	}

	void Update () {
		if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
			ChangeRail();
		Move();
	}

	void Move() {
		if (transform.position == nextWaypoint.transform.position)
			NextWaypoint();
		MoveToWaypoint();
	}

	void ChangeRail() {
		int idx = currentRailIndex == 0 ? 1 : 0;
		currentRail = rails[idx];
		currentRailIndex = idx;
		NextWaypoint(true);
		animController.Jump();
	}

	void NextWaypoint(bool changingRail = false) {
		if (changingRail)
		{
			nextWaypoint = currentRail.GetNearestWaypoint(transform.position);
			nextWaypoint = currentRail.GetNextWaypoint();
		}
		else
		{
			nextWaypoint = currentRail.GetNextWaypoint();
		}
	}

	void MoveToWaypoint() {
		float speed = IsTouchingRail() ? this.speed : (this.speed * 2); // maintain horizontal speed when moving diagonally
		transform.position = Vector2.MoveTowards(
			transform.position,
			nextWaypoint.transform.position,
			Time.deltaTime * speed
		);
	}

	bool IsTouchingRail() {
		bool isTouching = Mathf.Approximately(
			Mathf.Abs(transform.position.y),
			Mathf.Abs(nextWaypoint.transform.position.y)
		);
		return isTouching;
	}

}
