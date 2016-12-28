using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HitObstacles : MonoBehaviour {
	public AudioSource audioSource = null;
	public AudioClip audioClip = null;
	public GameObject restart = null;
	private Animator animator;
	private bool stop = false;
	private Vector3 restartStartPosition = Vector3.zero;

	void Start() {
		animator = GetComponent<Animator>();
		restartStartPosition = restart.transform.position;
		restart.transform.position = Vector3.up * 50;
	}

	void Update() {
		if (!stop || !Input.anyKeyDown) {
			return;
		}
		SceneManager.LoadScene("Game");
		Time.timeScale = 1;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if (audioSource && audioClip) {
			audioSource.PlayOneShot(audioClip, 1);
		}
		restart.transform.position = restartStartPosition;
		Time.timeScale = 0;
		stop = true;
		animator.SetTrigger("hit");
		Animator otherAnimator = collider.gameObject.GetComponent<Animator>();
		if (otherAnimator == null) {
			return;
		}
		otherAnimator.SetTrigger("hit");
	}
}
