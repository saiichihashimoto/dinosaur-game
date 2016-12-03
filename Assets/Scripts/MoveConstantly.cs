using UnityEngine;
using System.Collections;

public class MoveConstantly : MonoBehaviour {
	public Level level = null;
	public float speedMultiplier = 1;

	void Update() {
		transform.position += Vector3.left * Time.deltaTime * level.mainSpeed * speedMultiplier;
	}
}
