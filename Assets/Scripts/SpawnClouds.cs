using UnityEngine;
using System.Collections;

public class SpawnClouds : MonoBehaviour {
	public Level level = null;
	public GameObject ground = null;
	public GameObject cloud = null;
	public float minimumCloudHeight = 1;
	public float maximumCloudHeight = 1;
	private float distance = 0;
	private float spawnAt = 0;

	void Start() {
		distance = 0f;
		spawnAt = 0f;
	}

	void Update() {
		distance += Time.deltaTime * level.mainSpeed;
		if (distance < spawnAt) {
			return;
		}
		SpawnCloud();
	}

	private void SpawnCloud() {
		GameObject obstacle = (GameObject) Instantiate(cloud);
		obstacle.transform.position = new Vector3(transform.localScale.x / 2, minimumCloudHeight + Random.value * (maximumCloudHeight - minimumCloudHeight), 0);
		obstacle.GetComponent<MoveRelatively>().level = level;
		obstacle.GetComponent<DestroyOnLeftEdge>().ground = gameObject;

		spawnAt = (3 + 100 + Random.value * 300) * 4;
		distance = 0f;
	}
}
