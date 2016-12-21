using UnityEngine;
using System.Collections;

public class DestroyOnLeftEdge : MonoBehaviour {
	public GameObject ground = null;

	void Update () {
		if (transform.position.x > -ground.transform.localScale.x / 2) {
			return;
		}
		Destroy(gameObject);
	}
}
