﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreboardManager : MonoBehaviour {

	public Image victoryImage;
	public Image defeatImage;
	public Text scoreText;
	public Button continueButton;
	public Button menuButton;

	public void WonGame(int score, int total) {
		victoryImage.gameObject.SetActive(true);
		defeatImage.gameObject.SetActive(false);
		EndGame(score, total);
	}

	public void LostGame(int score, int total) {
		victoryImage.gameObject.SetActive(false);
		defeatImage.gameObject.SetActive(true);
		EndGame(score, total);
	}

	void EndGame(int score, int total) {
		scoreText.gameObject.SetActive(true);
		scoreText.text = GetScoreText(score, total);
		continueButton.gameObject.SetActive(true);
		menuButton.gameObject.SetActive(true);
	}

	string GetScoreText(int score, int total) {
		return score + "/" + total;
	}

	public void GoToLevelSelection() {
		SceneManager.LoadScene("MainMenu");
	}

}
