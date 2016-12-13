using UnityEngine;
using System.Collections;

public class MoveConstantly : MonoBehaviour {
	public Level level = null;
	public float minimumSpeedMultiplier = 1;
	public float maximumSpeedMultiplier = 1;
	private float actualSpeedMultiplier;

	void Start() {
		actualSpeedMultiplier = minimumSpeedMultiplier + Random.value * (maximumSpeedMultiplier - minimumSpeedMultiplier);
	}

	void Update() {
		transform.position += Vector3.left * Time.deltaTime * level.mainSpeed * actualSpeedMultiplier;
	}
}
