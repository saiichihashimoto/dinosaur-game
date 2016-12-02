using UnityEngine;
using System.Collections;

public class AnimateTexture : MonoBehaviour {
	public Renderer renderer = null;
	public Vector2 direction = Vector2.up;
	public float movementSpeed = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		renderer.material.mainTextureOffset += direction.normalized * Time.deltaTime * movementSpeed / transform.localScale.x * renderer.material.mainTextureScale.x;
	}
}
