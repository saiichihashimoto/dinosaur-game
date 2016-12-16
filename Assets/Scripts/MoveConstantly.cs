using UnityEngine;
using System.Collections;

public class MoveConstantly : MonoBehaviour {
	public float speedMultiplier = 1;
	public float restartAt = -5000;
	private Vector3 startAt;

	void Start() {
		startAt = transform.position;
	}

	void Update() {
		transform.position += Vector3.left * Time.deltaTime * speedMultiplier;
		if (transform.position.x > restartAt) {
			return;
		}
		transform.position = startAt;
	}
}
