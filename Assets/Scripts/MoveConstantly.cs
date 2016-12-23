using UnityEngine;
using System.Collections;

public class MoveConstantly : MonoBehaviour {
	public float speedMultiplier = 1;
	public float startAt = 5000;
	public float restartAt = -5000;

	void Update() {
		transform.position += Vector3.left * Time.deltaTime * speedMultiplier;
		if (transform.position.x > restartAt) {
			return;
		}
		transform.position += Vector3.right * (startAt - restartAt);
	}
}
