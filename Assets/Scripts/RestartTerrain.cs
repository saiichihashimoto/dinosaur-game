using UnityEngine;
using System.Collections;

public class RestartTerrain : MonoBehaviour {
	public SpriteRenderer renderer;
	public int terrainOffset = 0;

	// Use this for initialization
	void Start () {
		transform.position += terrainOffset * renderer.bounds.size.x * Vector3.right;
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x > -renderer.bounds.size.x) {
			return;
		}
		transform.position += 2 * renderer.bounds.size.x * Vector3.right;
	}
}
