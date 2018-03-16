using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumberMaster : MonoBehaviour {

	public int min = 0;
	public int max = 1000;
	public Text randomText;
	public Text newNumberText;
	public Text scoreText;
	public Text yourScore;
	public Text msg;
	public GameObject gameObj;
	public GameObject startObj;

	private int randomNumber;
	private int score = 0;
	private bool youWin = false;
	private bool gOver = false;
	private float timer = 0f;

	void Start () {
		gameObj.SetActive (false);
		startObj.SetActive (true);
		if (score > 0) {
			yourScore.gameObject.SetActive (true);
		} else {
			yourScore.gameObject.SetActive (false);
		}
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

		if (gOver) {
			timer += Time.deltaTime;

			if (timer > 2f) {
				gameObj.SetActive (false);
				startObj.SetActive (true);
				timer = 0f;
				gOver = !gOver;
			}
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			check ("higher");
		}

		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			check ("lower");
		}

		if (Input.GetKeyDown (KeyCode.Return)) {
			startGame ();
		}
	}

	public void check(string type) {
		int newNumer = Random.Range (min, max + 1);

		newNumberText.text = newNumer.ToString ();

		switch (type) {
		case "lower":
			if (newNumer < randomNumber) {
				win (newNumer);
			} else {
				gameOver ();
			}
			break;
		case "higher":
			if (newNumer > randomNumber) {
				win (newNumer);
			} else {
				gameOver ();
			}
			break;
		}
	}

	public void startGame() {
		newNumberText.text = "";
		msg.color = Color.white;
		msg.text = "Please choose lower or higher!";
		scoreText.text = "Score: 0";
		score = 0;
		randomNumber = Random.Range (min, max + 1);
		randomText.text = randomNumber.ToString ();
		gameObj.SetActive (true);
		startObj.SetActive (false);
	}

	public void win(int number) {
		youWin = true;
		randomNumber = number;
		randomText.text = randomNumber.ToString ();
		msg.text = "You have won!";
		msg.color = Color.white;
		newNumberText.color = Color.green;
		score += 1;
		scoreText.text = "Score: " + score.ToString ();
	}

	private void gameOver() {
		gOver = true;
		msg.text = "Game over!";
		msg.color = Color.red;
		newNumberText.color = Color.red;
		yourScore.text = "Your score is " + score.ToString ();
		yourScore.gameObject.SetActive (true);
	}
}
