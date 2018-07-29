using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	protected bool isDying;
	private EnemyAnimatorController animController;
	private AudioSource audioSource;

	protected void Awake() {
		this.animController = GetComponent<EnemyAnimatorController>();
		this.audioSource = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		audioSource.Play();
		animController.Die();
	}

	public void DestroySelf() {
		Destroy(gameObject);
	}

}
