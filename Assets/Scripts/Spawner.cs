using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	// Types of Spawn
	public bool isEnemy = false;
	public bool isBonus = false;
	public bool isMeteor = false;

	public float spawnTime = 2.5f;
	public float spawnDelay = 1.5f;
	public GameObject[] enemies;
	public GameObject[] bonuses;
	public GameObject[] meteors;

	// Use this for initialization
	void Start () {
		Random.seed = System.DateTime.Today.Millisecond;
		if (isEnemy)
			InvokeRepeating ("SpawnEnemy", spawnDelay, spawnTime);
		else if (isBonus)
			InvokeRepeating ("SpawnBonus", spawnDelay, spawnTime);
		else if (isMeteor) {
			InvokeRepeating ("SpawnMeteor", spawnDelay, spawnTime);
		}
	}
	
	// Spawn Enemy
	void SpawnEnemy () {
		float rnd = Random.Range (0, 1f);
		if(GameController.isStart && rnd > 0.5)
		{
			int enemyIndex = Random.Range (0, enemies.Length);
			float offset = Random.Range (-0.1f, 0.1f);
			Vector3 newPosition = transform.position + new Vector3 (0f, offset, 0f);
			Instantiate (enemies [enemyIndex], newPosition, enemies [enemyIndex].transform.rotation);
		}
	}

	// Spawn Bonus
	void SpawnBonus(){
		int bonusIndex = Random.Range (0, bonuses.Length);
		float offset = Random.Range (-3f, 3f);
		Vector3 newPosition = transform.position + new Vector3 (0f, offset, 0f);
		Instantiate (bonuses [bonusIndex], newPosition, bonuses [bonusIndex].transform.rotation);
	}

	// Spawn Meteor
	void SpawnMeteor(){
		int meteorIndex = Random.Range (0, meteors.Length);
		float offset = Random.Range (-3f, 3f);
		Vector3 newPosition = transform.position + new Vector3 (0f, offset, 0f);
		Instantiate (meteors [meteorIndex], newPosition, meteors [meteorIndex].transform.rotation);
	}
}
