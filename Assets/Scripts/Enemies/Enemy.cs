﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D collider) {
		Destroy(gameObject);
	}
}