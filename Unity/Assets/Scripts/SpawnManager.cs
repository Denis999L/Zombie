using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public Vector3[] spawnPositions;
    public int maxEnemies;
    public float spawnDelay;

    private int numEnemiesSpawned = 0;
    private int numEnemiesDestroyed = 0;

    public Text enemiesRemainingText;
    public GameObject gameOverCanvas;

    private float spawnTimer = 0f;

    void Start()
    {
        UpdateEnemiesRemainingText();
    }

    void Update()
    {
        if (numEnemiesSpawned < maxEnemies)
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer >= spawnDelay)
            {
                SpawnEnemy();
                spawnTimer = 0f;
            }
        }
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemies.Length);
        int randomPositionIndex = Random.Range(0, spawnPositions.Length);
        Vector3 spawnPosition = spawnPositions[randomPositionIndex];
        Instantiate(enemies[randomIndex], spawnPosition, Quaternion.identity);
        numEnemiesSpawned++;
        UpdateEnemiesRemainingText();
    }
    
    public void EnemyDestroyed()
    {
        numEnemiesDestroyed++;
        UpdateEnemiesRemainingText();
    }


    void UpdateEnemiesRemainingText()
    {
        enemiesRemainingText.text = "Enemies Remaining: " + (maxEnemies - numEnemiesDestroyed);

        if (numEnemiesDestroyed == maxEnemies)
        {
            ShowGameOverCanvas();
        }
    }

    public void ShowGameOverCanvas()
    {
        Debug.Log("Game Over!");
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }

}

