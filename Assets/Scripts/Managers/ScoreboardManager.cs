using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreboardManager : MonoBehaviour {

	public Text victoryText;
	public Text defeatText;
	public Text scoreText;
	public Button continueButton;

	public void WonGame(int score, int total) {
		victoryText.gameObject.SetActive(true);
		defeatText.gameObject.SetActive(false);
		EndGame(score, total);
		scoreText.color = victoryText.color;
	}

	public void LostGame(int score, int total) {
		victoryText.gameObject.SetActive(false);
		defeatText.gameObject.SetActive(true);
		EndGame(score, total);
		scoreText.color = defeatText.color;
	}

	void EndGame(int score, int total) {
		scoreText.gameObject.SetActive(true);
		scoreText.text = GetScoreText(score, total);
		continueButton.gameObject.SetActive(true);
	}

	string GetScoreText(int score, int total) {
		return score + "/" + total;
	}

	public void GoToLevelSelection() {
		SceneManager.LoadScene("MainMenu");
	}

}
