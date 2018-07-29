using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour {

	private Animator animator;
	private SpriteRenderer spriteRenderer;

	void Awake() {
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void Stop() {
		animator.SetBool("isMoving", false);
	}

	public void Move() {
		animator.SetBool("isMoving", true);
	}

	public void Collision() {
		animator.SetTrigger("Collision");
	}

	public void Victory() {
		animator.SetTrigger("Victory");
	}

	public void Defeat() {
		animator.SetTrigger("Defeat");
	}

	public void Born() {
		animator.SetTrigger("Born");
	}

	public void Jump() {
		animator.SetTrigger("Jump");
		FlipSprite();
	}

	public void SetJumping(bool isJumping) {
		animator.SetBool("isJumping", isJumping);
	}

	void FlipSprite() {
		spriteRenderer.flipY = !spriteRenderer.flipY;
	}

}
