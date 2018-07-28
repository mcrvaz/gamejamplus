using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rail : MonoBehaviour {

	private List<GameObject> waypoints;
	private IEnumerator<GameObject> waypointEnum;

	void Awake() {
		var waypointsTransform = new List<Transform>(GetComponentsInChildren<Transform>());
		this.waypoints = new List<GameObject>();
		waypointsTransform.ForEach(e => waypoints.Add(e.gameObject));
	}

	void Start () {
		waypointEnum = waypoints.GetEnumerator();
		waypointEnum.MoveNext();
	}

	public GameObject GetNextWaypoint() {
		waypointEnum.MoveNext();
		return waypointEnum.Current;
	}
}
