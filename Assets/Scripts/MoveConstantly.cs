using UnityEngine;
using System.Collections;

public class MoveConstantly : MonoBehaviour {
	public Level level = null;
	public float minimumSpeedMultiplier = 1;
	public float maximumSpeedMultiplier = 1;

	void Update() {
		transform.position += Vector3.left * Time.deltaTime * level.mainSpeed * (minimumSpeedMultiplier + Random.value * (maximumSpeedMultiplier - minimumSpeedMultiplier));
	}
}
