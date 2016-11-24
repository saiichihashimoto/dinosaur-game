using UnityEngine;
using System.Collections;

public class MoveConstantly : MonoBehaviour {
	public float movementSpeed = 1;

	void Update() {
		transform.position += Vector3.left * Time.deltaTime * movementSpeed;
	}
}
