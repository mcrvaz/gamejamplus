using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : Obstacle
{
	public float speed;
	private bool isExtending;
	private Vector3 target;

	void Start()
	{
		isExtending = true;
		target = transform.position;
	}

	void Update () {
		if (transform.position.y == target.y)
		{
			isExtending = !isExtending;
			target.y = transform.position.y + (isExtending ? -2 : 2);
		}
		transform.position = Vector2.MoveTowards(
			transform.position,
			target,
			Time.deltaTime * speed
		);
	}
}
