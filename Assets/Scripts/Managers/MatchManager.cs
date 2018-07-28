using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour {

	private int qttVirus;
	private int score = 0;

	void Awake() {
		this.qttVirus = GameObject.FindObjectsOfType<Enemy>().Length;
	}

	public void EndMatch() {
		InputManager.disableInput = true;
	}

	public void ScorePoint() {
		score++;
	}

	public bool WonGame() {
		return score > (qttVirus / 2);
	}

}
