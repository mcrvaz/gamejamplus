using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour {

	private Animator anim;

	void Awake() {
		anim = GetComponent<Animator>();
		anim.SetBool("isMoving", true);
	}

}
