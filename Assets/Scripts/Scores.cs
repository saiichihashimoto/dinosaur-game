using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scores : MonoBehaviour {
	public Text score = null;
	public Text highScore = null;
	public float pointsPerSecond = 100;
	private float currentScore = 0;
	private static float highestScore = 0;

	void Update() {
		currentScore = Time.timeSinceLevelLoad * pointsPerSecond;
		score.text = currentScore.ToString("00000");
	}

	void Awake() {
		highScore.text = highestScore.ToString("00000");
	}

	void OnDestroy() {
		highestScore = Mathf.Max(currentScore, highestScore);
	}
}
