using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scores : MonoBehaviour {
	public Level level = null;
	public AudioSource audioSource = null;
	public AudioClip audioClip = null;
	public Number score = null;
	public Number highScore = null;
	private float lastHundred = 0;
	private static float highestScore = 0;

	void Update() {
		if (audioSource && audioClip && (int) (level.getDistance() / 100) != lastHundred) {
			audioSource.PlayOneShot(audioClip, 1);
			lastHundred = (int) (level.getDistance() / 100);
		}
		score.Value = (int) level.getDistance();
		highScore.Value = (int) highestScore;
	}

	void Awake() {
		highScore.Value = (int) highestScore;
	}

	void OnDestroy() {
		highestScore = Mathf.Max(level.getDistance(), highestScore);
	}
}
