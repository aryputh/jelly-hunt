using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessEnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public GameObject[] enemySpawners;
    public float startDelay;
    public float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, spawnDelay);
    }

    // Spawns an enemy at a random lcoation
    void SpawnEnemy()
	{
        Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], enemySpawners[Random.Range(0, enemySpawners.Length)].transform.position, Quaternion.identity);
	}
}
