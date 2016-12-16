using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scores : MonoBehaviour {
	public Level level = null;
	public AudioSource audioSource = null;
	public AudioClip audioClip = null;
	public Text score = null;
	public Text highScore = null;
	private float lastHundred = 0;
	private static float highestScore = 0;

	void Update() {
		if (audioSource && audioClip && (int) (level.getDistance() / 100) != lastHundred) {
			audioSource.PlayOneShot(audioClip, 1);
			lastHundred = (int) (level.getDistance() / 100);
		}
		score.text = level.getDistance().ToString("00000");
	}

	void Awake() {
		highScore.text = highestScore.ToString("00000");
	}

	void OnDestroy() {
		highestScore = Mathf.Max(level.getDistance(), highestScore);
	}
}
