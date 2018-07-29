using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimatorController : MonoBehaviour {

	private Animator animator;

	void Awake() {
		animator = GetComponent<Animator>();
	}

	public void Die() {
		animator.SetTrigger("Die");
	}

}
