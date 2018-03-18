using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NumberMaster : MonoBehaviour {

	public int min = 0;
	public int max = 1000;
	public Text randomText;
	public Text newNumberText;
	public Text scoreText;
	public Text highScore;
	public Text msg;
	public Text yourScore;
	public GameObject gameObj;
	public GameObject mainObj;
	public GameObject gameOverObj;

	private int randomNumber;
	private int gameScore = 0;
	private int gameHighScore;
	private bool youWin = false;
	private float timer = 0f;

	void Awake () {
		gameHighScore = PlayerPrefs.GetInt("HighScore");
		highScore.text = gameHighScore.ToString();
	}

	void Start () {
		gameObj.SetActive (false);
		gameOverObj.SetActive (false);
		mainObj.SetActive (true);
	}

	// Update is called once per frame
	void Update () {
		if (youWin) {
			timer += Time.deltaTime;
			if (timer > 1f) {
				msg.text = "Please choose lower or higher!";
				timer = 0f;
				youWin = !youWin;
			}
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			Check ("higher");
		}

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			Check ("lower");
		}

		if (Input.GetKeyDown (KeyCode.Return)) {
			InitGame ();
		}

		if (Input.GetKeyDown (KeyCode.Escape)) {
			QuitGame ();
		}
	}

	public void Check(string type) {
		int newNumer = Random.Range (min, max + 1);

		newNumberText.text = newNumer.ToString ();

		switch (type) {
		case "lower":
			if (newNumer < randomNumber) {
				Win (newNumer);
			} else {
				GameOver ();
			}
			break;
		case "higher":
			if (newNumer > randomNumber) {
				Win (newNumer);
			} else {
				GameOver ();
			}
			break;
		}
	}

	public void InitGame() {
		newNumberText.text = "";
		msg.color = Color.white;
		msg.text = "Please choose lower or higher!";
		scoreText.text = "Score: 0";
		gameScore = 0;
		randomNumber = Random.Range (min, max + 1);
		randomText.text = randomNumber.ToString ();
		gameObj.SetActive (true);
		mainObj.SetActive (false);
		gameOverObj.SetActive (false);
	}

	public void QuitGame () {
		Application.Quit ();
	}

	public void RestartGame () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void Win(int number) {
		youWin = true;
		randomNumber = number;
		randomText.text = randomNumber.ToString ();
		msg.text = "You have won!";
		msg.color = Color.white;
		newNumberText.color = Color.green;
		gameScore += 1;
		scoreText.text = "Score: " + gameScore.ToString ();
	}

	private void GameOver() {
		gameHighScore = PlayerPrefs.GetInt("HighScore");
		// Check and update highscore, if game score is greater than high score.
		if (gameScore > gameHighScore) {
			highScore.text = gameScore.ToString ();
			PlayerPrefs.SetInt("HighScore", gameScore);
			PlayerPrefs.Save();
		}
		newNumberText.color = Color.red;
		yourScore.text = "Your score is " + gameScore.ToString ();
		gameOverObj.SetActive (true);
	}
}
