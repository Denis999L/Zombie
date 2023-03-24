using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnTime = 5.0f;
    private float elapsedTime = 0.0f;
    private int enemyCount = 0;
    private int maxEnemies = 10;

    public float spawnRangeX = 6.5f;
    public float spawnRangeY = 0.1f;
    public float spawnRangeZ = 4f;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= spawnTime && enemyCount < maxEnemies)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            Vector3 spawnPosition = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), spawnRangeY, Random.Range(-spawnRangeZ, spawnRangeZ));
            Instantiate(enemyPrefabs[randomIndex], spawnPosition, Quaternion.identity);
            elapsedTime = 0.0f;
            enemyCount++;
        }
    }
}
