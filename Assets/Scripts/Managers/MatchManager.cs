using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour {

	private int qttVirus;
	private int score = 0;
	private ScoreboardManager scoreboardManager;

	void Awake() {
		this.qttVirus = FindObjectsOfType<Enemy>().Length;
		this.scoreboardManager = FindObjectOfType<ScoreboardManager>();
	}

	public void EndMatch() {
		InputManager.disableInput = true;
		if (WonGame()) {
			scoreboardManager.WonGame(score, qttVirus);
		} else {
			scoreboardManager.LostGame(score, qttVirus);
		}
	}

	public void ScorePoint() {
		score++;
	}

	public bool WonGame() {
		return score > (qttVirus / 2);
	}

}
