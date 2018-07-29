using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : Enemy {

	public float speed;
	public List<Waypoint> waypoints;

	private Waypoint destination;
	private IEnumerator<Waypoint> waypointEnumerator;

	new void Awake() {
		base.Awake();
		waypointEnumerator = waypoints.GetEnumerator();
		ResetEnumerator(waypointEnumerator);
	}

	void Start() {
		ChangeDestination();
	}

	void Update () {
		if (ReachedDestination()) ChangeDestination();
		Move();
	}

	bool ReachedDestination() {
		return transform.position == destination.transform.position;
	}

	void ChangeDestination() {
		if (!waypointEnumerator.MoveNext())
			ResetEnumerator(waypointEnumerator);
		destination = waypointEnumerator.Current;
	}

	void ResetEnumerator(IEnumerator ienum) {
		ienum.Reset();
		ienum.MoveNext();
	}

	void Move() {
		transform.position = Vector2.MoveTowards(
			transform.position,
			destination.transform.position,
			Time.deltaTime * speed
		);
	}
}
