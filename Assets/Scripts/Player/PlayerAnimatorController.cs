using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour {

	private Animator animator;
	private SpriteRenderer spriteRenderer;

	void Awake() {
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		animator.SetBool("isMoving", true);
	}

	public void Jump() {
		animator.SetTrigger("Jump");
	}

	public void SetJumping(bool isJumping) {
		animator.SetBool("isJumping", isJumping);
	}

	void FlipSprite() {
		spriteRenderer.flipY = !spriteRenderer.flipY;
	}

}
