using UnityEngine;
using System.Collections;

public class AnimateTexture : MonoBehaviour {
	public Level level = null;
	public Renderer renderer = null;
	public Vector2 direction = Vector2.up;
	public float speedMultiplier = 1;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		renderer.material.mainTextureOffset += direction.normalized * Time.deltaTime * level.mainSpeed * speedMultiplier * renderer.material.mainTextureScale.x / transform.localScale.x;
	}
}
