using UnityEngine;
using System.Collections;

public class SpawnObstacles : MonoBehaviour {
	public Level level = null;
	public float minimumSpawnDistance = 1;
	public float maximumSpawnDistance = 1;
	private float distance = 0;
	private float spawnAt = 0;

	void Start() {
		distance = 0f;
		spawnAt = (minimumSpawnDistance + Random.value * (maximumSpawnDistance - minimumSpawnDistance));
	}

	void Update() {
		distance += Time.deltaTime * level.mainSpeed;
		if (distance < spawnAt) {
			return;
		}
		SpawnObstacle();
	}

	private void SpawnObstacle() {
		GameObject obstacle = (GameObject) Instantiate(level.obstacles[Random.Range(0, level.obstacles.Length)]);
		obstacle.transform.position = new Vector3(transform.localScale.x/2, transform.position.y, 0);
		obstacle.GetComponent<MoveConstantly>().level = level;

		distance = 0f;
		spawnAt = (minimumSpawnDistance + Random.value * (maximumSpawnDistance - minimumSpawnDistance));
	}
}
