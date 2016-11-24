using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HitObstacles : MonoBehaviour {
	private bool stop = false;

	void Update() {
		if (!stop || !Input.anyKeyDown) {
			return;
		}
		SceneManager.LoadScene("Game");
		Time.timeScale = 1;
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Time.timeScale = 0;
		stop = true;
	}
}
