using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {
	public GameObject[] obstacles;
	public float mainSpeed = 10;
	public float maxSpeed = 10;
	public float acceleration = 10;
	private float distanceRan = 0f;

	// Use this for initialization
	void Start () {
		distanceRan = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		distanceRan += mainSpeed * Time.deltaTime / 4;
		if (mainSpeed < maxSpeed) {
			mainSpeed += acceleration;
		}
	}

	public float getDistance() {
		return distanceRan;
	}
}
