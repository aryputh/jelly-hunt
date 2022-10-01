using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessEnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject[] spawners;
    public float startDelay;
    public float spawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", startDelay, spawnDelay);
    }

    void SpawnEnemy()
	{
        int spawnerId = Random.Range(0, spawners.Length);

        Instantiate(enemyPrefab, spawners[spawnerId].transform.position, Quaternion.identity);
	}
}
