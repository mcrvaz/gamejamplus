using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

	[Range(0, 20)]
	public float speed;
	public GameObject startingRail;

	private MatchManager matchManager;
	private PlayerAnimatorController animController;

	private List<Rail> rails;
	private Rail currentRail;
	private int currentRailIndex;
	private Waypoint nextWaypoint;
	private bool isChangingRail;

	void Awake() {
		var startingRail = this.startingRail.GetComponent<Rail>();
		this.rails = new List<Rail>(FindObjectsOfType<Rail>());
		// this.currentRailIndex = rails.FindIndex(e => startingRail);
		this.currentRailIndex = 1;
		this.currentRail = rails[currentRailIndex];
		this.matchManager = FindObjectOfType<MatchManager>();
		this.animController = GetComponent<PlayerAnimatorController>();
	}

	void Start() {
		NextWaypoint();
	}

	void Update () {
		if (InputManager.isClicking() || InputManager.isTouching()) ChangeRail();
		Move();
	}

	void Move() {
		if (transform.position == nextWaypoint.transform.position) {
			if (nextWaypoint.isLastEndpoint) EndMatch();
			NextWaypoint();
		}
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
		if (changingRail) {
			nextWaypoint = currentRail.GetNearestWaypoint(transform.position);
			nextWaypoint = currentRail.GetNextWaypoint();
		} else {
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
		animController.SetJumping(!isTouching);
		return isTouching;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.CompareTag(Tags.ENEMY)) matchManager.ScorePoint();
	}

	void EndMatch() {
		matchManager.EndMatch();
		animController.Stop();
	}

}
