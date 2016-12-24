using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HitObstacles : MonoBehaviour {
	public AudioSource audioSource = null;
	public AudioClip audioClip = null;
	public GameObject restart = null;
	private Animator animator;
	private bool stop = false;

	void Start() {
		animator = GetComponent<Animator>();
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
		restart.transform.position = Vector3.zero;
		Time.timeScale = 0;
		stop = true;
		animator.SetTrigger("hit");
	}
}
