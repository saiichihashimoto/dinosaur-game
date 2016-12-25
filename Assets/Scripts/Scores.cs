using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scores : MonoBehaviour {
	public Level level = null;
	public AudioSource audioSource = null;
	public AudioClip audioClip = null;
	public Number score = null;
	public Number highScore = null;
	public Number flashScore = null;
	public int flashIterations = 10;
	public float flashDuration = 1;
	private int lastHundred = 0;
	private Vector3 scoreStartPosition = Vector3.zero;
	private int iterated = 0;
	private static float highestScore = 0;

	void Start() {
		flashScore.transform.position = score.transform.position + Vector3.up * 50;
	}

	void Update() {
		if (audioSource && audioClip && (int) (level.getDistance() / 100) != lastHundred) {
			lastHundred = (int) (level.getDistance() / 100);
			flashScore.Value = lastHundred * 100;
			StartCoroutine(FlashScore());
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

	IEnumerator FlashScore() {
		scoreStartPosition = score.transform.position;
		score.transform.position = scoreStartPosition + Vector3.up * 50;
		iterated = 0;
		audioSource.PlayOneShot(audioClip, 1);
		return FlashScore(false);
	}

	IEnumerator FlashScore(bool showScore) {
		flashScore.transform.position = scoreStartPosition + (showScore ? Vector3.zero : Vector3.up * 50);
		if (showScore) {
			iterated++;
		}
		if (iterated >= flashIterations) {
			score.transform.position = scoreStartPosition;
			flashScore.transform.position = scoreStartPosition + Vector3.up * 50;
		} else {
			yield return new WaitForSeconds(flashDuration);
			StartCoroutine(FlashScore(!showScore));
		}
	}
}
