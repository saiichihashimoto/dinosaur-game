using UnityEngine;
using System.Collections;

public class DestroyOnLeftEdge : MonoBehaviour {
	public float leftEdgeX = 0;

	void Start () {
	}

	void Update () {
		if (transform.position.x > leftEdgeX) {
			return;
		}
		Destroy(gameObject);
	}
}
