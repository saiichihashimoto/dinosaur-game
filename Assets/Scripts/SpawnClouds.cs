using UnityEngine;
using System.Collections;

public class SpawnClouds : MonoBehaviour {
	public Level level = null;
	public GameObject ground = null;
	public GameObject cloud = null;
	public float minimumSpawnTime = 1;
	public float maximumSpawnTime = 1;
	public float minimumCloudHeight = 1;
	public float maximumCloudHeight = 1;

	// Use this for initialization
	void Start() {
		StartCoroutine(SpawnObstacle());
	}

	private IEnumerator SpawnObstacle() {
		GameObject obstacle = (GameObject) Instantiate(cloud);
		obstacle.transform.position = new Vector3(transform.localScale.x/2, minimumCloudHeight + Random.value * (maximumCloudHeight - minimumCloudHeight), 0);
		obstacle.GetComponent<MoveConstantly>().level = level;
		obstacle.GetComponent<DestroyOnLeftEdge>().ground = gameObject;

		yield return new WaitForSeconds(minimumSpawnTime + Random.value * (maximumSpawnTime - minimumSpawnTime));
		StartCoroutine(SpawnObstacle());
	}
}
