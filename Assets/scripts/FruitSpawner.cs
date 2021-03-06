using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour {

	public GameObject fruitPrefab;
	public Transform[] spawnPoints;

	public float minDelay = .1f;
	public float maxDelay = 1f;

	Vector3 screenSize;

	// Use this for initialization
	void Start () {

		StartCoroutine(SpawnFruits(spawnPoints.Length));

	}

	IEnumerator SpawnFruits (int length)
	{
		while (true)
		{
			float delay = Random.Range(minDelay, maxDelay);
			yield return new WaitForSeconds(delay);

			int spawnIndex = Random.Range(0, spawnPoints.Length);
			Debug.Log(spawnPoints.Length);
			Transform spawnPoint = spawnPoints[spawnIndex];

			GameObject spawnedFruit = Instantiate(fruitPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
			Destroy(spawnedFruit, 5f);
		}
	}
	
}
