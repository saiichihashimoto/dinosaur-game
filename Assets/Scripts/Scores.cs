using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scores : MonoBehaviour {
	public AudioSource audioSource = null;
	public AudioClip audioClip = null;
	public Text score = null;
	public Text highScore = null;
	public float pointsPerSecond = 100;
	private float currentScore = 1;
	private static float highestScore = 0;

	void Update() {
		int before = (int) (currentScore / 100);
		currentScore += Time.deltaTime * pointsPerSecond;
		int after = (int) (currentScore / 100);
		if (audioSource && audioClip && before != after) {
			audioSource.PlayOneShot(audioClip, 1);
		}
		score.text = currentScore.ToString("00000");
	}

	void Awake() {
		highScore.text = highestScore.ToString("00000");
	}

	void OnDestroy() {
		highestScore = Mathf.Max(currentScore, highestScore);
	}
}
