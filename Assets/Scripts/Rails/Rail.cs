﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour {

	public bool isCircular;

	private List<GameObject> waypoints;
	private int waypointIndex = 0;

	void Awake() {
		var waypointsObj = new List<Waypoint>(GetComponentsInChildren<Waypoint>());
		waypoints = new List<GameObject>();
		waypointsObj.ForEach(e => waypoints.Add(e.gameObject));
	}

	public GameObject GetNextWaypoint() {
		if (waypointIndex < waypoints.Count - 1) {
			waypointIndex++;
		} else if (isCircular){
			waypointIndex = 0;
		}
		return waypoints[waypointIndex];
	}

	public GameObject GetNearestWaypoint(Vector3 position) {
		waypointIndex = 0;
		GameObject nearest = waypoints[waypointIndex];
		float nearestDistance = Vector2.Distance(nearest.transform.position, position);
		for (int i = 1; i < waypoints.Count; i++) {
			float itemDistance = Vector2.Distance(waypoints[i].transform.position, position);
			if (itemDistance < nearestDistance) {
				waypointIndex = i;
				nearest = waypoints[waypointIndex];
				nearestDistance = Vector2.Distance(nearest.transform.position, position);
			}
		}
		return nearest;
	}
}
