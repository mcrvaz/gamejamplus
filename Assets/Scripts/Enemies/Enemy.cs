using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	protected bool isDying;
	private EnemyAnimatorController animController;

	protected void Awake() {
		this.animController = GetComponent<EnemyAnimatorController>();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		animController.Die();
	}

	public void DestroySelf() {
		Destroy(gameObject);
	}

}
