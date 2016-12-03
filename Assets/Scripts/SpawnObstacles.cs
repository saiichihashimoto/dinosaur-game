using UnityEngine;
using System.Collections;

public class SpawnObstacles : MonoBehaviour {
	public Level level = null;
	public float minimumSpawnTime = 1;
	public float maximumSpawnTime = 1;

	// Use this for initialization
	void Start() {
		StartCoroutine(SpawnObstacle());
	}

	private IEnumerator SpawnObstacle() {
		GameObject obstacle = (GameObject) Instantiate(level.obstacles[Random.Range(0, level.obstacles.Length)]);
		obstacle.transform.position = new Vector3(transform.localScale.x/2, transform.position.y, 0);
		obstacle.GetComponent<MoveConstantly>().level = level;

		yield return new WaitForSeconds(minimumSpawnTime + Random.value * (maximumSpawnTime - minimumSpawnTime));
		StartCoroutine(SpawnObstacle());
	}
}
