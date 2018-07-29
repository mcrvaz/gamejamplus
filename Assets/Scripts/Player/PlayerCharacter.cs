using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour {

	[Range(0, 20)]
	public float speed;
	public List<Rail> rails;

	private PlayerAnimatorController animController;
	private MatchManager matchManager;
	private AudioSource audioSource;

	private Rail currentRail;
	private int currentRailIndex;
	private Waypoint nextWaypoint;
	private bool isChangingRail;
	private bool stopMoving;

	void Awake() {
		this.currentRailIndex = 0;
		this.matchManager = FindObjectOfType<MatchManager>();
		this.currentRailIndex = rails.Count - 1;
		this.currentRail = rails[currentRailIndex];
		this.animController = GetComponent<PlayerAnimatorController>();
		this.audioSource = GetComponent<AudioSource>();
	}

	void Start() {
		StartCoroutine(IntroAnimation());
		NextWaypoint();
	}

	void Update () {
		if (InputManager.isClicking() || InputManager.isTouching()) {
			ChangeRail();
		}
		if (!stopMoving) Move();
	}

	IEnumerator IntroAnimation() {
		stopMoving = true;
		InputManager.disableInput = true;
		animController.Born();
		yield return new WaitForSeconds(1.5f);
		InputManager.disableInput = false;
		stopMoving = false;
		animController.Move();
	}

	void Move() {
		if (transform.position == nextWaypoint.transform.position) {
			if (nextWaypoint.isLastEndpoint) {
				matchManager.ReachEndWaypoint();
				EndMatch();
			}
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
		audioSource.Play();
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
		animController.SetJumping(!isTouching);
		return isTouching;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (collider.CompareTag(Tags.ENEMY)) {
			matchManager.ScorePoint();
		} else if (collider.CompareTag(Tags.OBSTACLE)) {
			EndMatch();
		}
	}

	void EndMatch() {
		matchManager.EndMatch();
		stopMoving = true;
		if (matchManager.WonGame()) {
			animController.Victory();
		} else {
			animController.Defeat();
		}
	}
}
