using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
	[SerializeField]
	TMP_Text scoreText;

	private int score = 0;

	public int Score {
		get {
			return score;
		}
		set {
			score = value;
			if(scoreText != null) {
				scoreText.text = "Score: " + score.ToString();
			}
		}
	}

	private void Start() {
		Score = 0;
	}
}
