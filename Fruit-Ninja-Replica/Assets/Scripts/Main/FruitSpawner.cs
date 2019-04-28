using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {

	public GameObject fruitPrefab;
	public Transform[] spawnPoints;

	public float minDelay = .1f;
	public float maxDelay = 1f;

	// Use this for initialization
	void Start () {
		StartCoroutine(SpawnFruits());
	}

	IEnumerator SpawnFruits ()
	{
		while (true)
		{
			float delay = Random.Range(minDelay * (4 - GameDataManager.fruitSpawnSpeed), maxDelay * (4 - GameDataManager.fruitSpawnSpeed));
			yield return new WaitForSeconds(delay);

            if (!GameplayManager.isGameover)
            {
                int spawnIndex = Random.Range(0, spawnPoints.Length);
                Transform spawnPoint = spawnPoints[spawnIndex];

                GameObject spawnedFruit = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation);
                spawnedFruit.GetComponent<Rigidbody2D>().gravityScale = .5f * GameDataManager.gravity;
            }
		}
	}
	
}
