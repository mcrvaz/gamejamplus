using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour {

	private Animator anim;
	private SpriteRenderer spriteRenderer;

	void Awake() {
		anim = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		anim.SetBool("isMoving", true);
	}

	public void Jump() {
		FlipSprite();
		anim.SetTrigger("Jump");
	}

	void FlipSprite() {
		spriteRenderer.flipY = !spriteRenderer.flipY;
	}

}
