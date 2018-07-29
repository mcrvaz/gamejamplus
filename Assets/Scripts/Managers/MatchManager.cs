using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour {

	private int qttVirus;
	private int score = 0;
	private bool reachedEndWaypoint;

	private ScoreboardManager scoreboardManager;
	private Camera mainCamera;
	private PlayerCharacter player;

	void Awake() {
		this.qttVirus = FindObjectsOfType<Enemy>().Length;
		this.scoreboardManager = FindObjectOfType<ScoreboardManager>();
		this.mainCamera = FindObjectOfType<Camera>();
		this.player = FindObjectOfType<PlayerCharacter>();
		InputManager.disableInput = false;
	}

	public void EndMatch() {
		StartCoroutine(CameraUtils.CameraZoom(mainCamera, 20));
		StartCoroutine(CameraUtils.FocusOnObject(mainCamera, player.gameObject));
		InputManager.disableInput = true;
		if (WonGame()) {
			scoreboardManager.WonGame(score, qttVirus);
		} else {
			scoreboardManager.LostGame(score, qttVirus);
		}
	}

	public void ReachEndWaypoint() {
		reachedEndWaypoint = true;
		EndMatch();
	}

	public void ScorePoint() {
		score++;
	}

	public bool WonGame() {
		return reachedEndWaypoint && (score > (qttVirus / 2));
	}

}
