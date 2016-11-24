using UnityEngine;
using System.Collections;

public class SpawnObstacles : MonoBehaviour {
	public GameObject[] obstacles;
	public Vector3 initialPosition = Vector3.right;
	public float minimumSpawnTime = 1;
	public float maximumSpawnTime = 1;

	// Use this for initialization
	void Start() {
		StartCoroutine(SpawnObstacle());
	}

	private IEnumerator SpawnObstacle() {
		GameObject obstacle = (GameObject) Instantiate(obstacles[Random.Range(0, obstacles.Length - 1)]);
		obstacle.transform.position = initialPosition;

		yield return new WaitForSeconds(minimumSpawnTime + Random.value * (maximumSpawnTime - minimumSpawnTime));
		StartCoroutine(SpawnObstacle());
	}
}
