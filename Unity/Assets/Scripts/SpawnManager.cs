using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPositions;
    public int maxEnemies = 10;
    public float spawnDelay = 1.0f;
    public Text enemiesRemainingText;
    public GameObject gameWinCanvas;

    private int enemiesRemaining;

    void Start()
    {
        enemiesRemaining = maxEnemies;
        StartCoroutine(SpawnEnemies());
        UpdateEnemiesRemainingText();
    }

    IEnumerator SpawnEnemies()
    {
        

        while (enemiesRemaining > 0)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length < maxEnemies)
            {
                Transform spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Length)];
                GameObject enemy = Instantiate(enemyPrefab, spawnPosition.position, spawnPosition.rotation);
                enemy.GetComponent<Enemy>().SetSpawnManager(this);

                enemiesRemaining--;
                UpdateEnemiesRemainingText();

                yield return new WaitForSeconds(spawnDelay);
            }
            else
            {
                yield return null;
            }
        }

        gameWinCanvas.SetActive(true);
    }

    public void EnemyDestroyed()
    {
        if (enemiesRemaining > 0)
        {
            enemiesRemaining--;
            UpdateEnemiesRemainingText(); 

            if (enemiesRemaining <= 0)
            {
                gameWinCanvas.SetActive(true);
            }
        }
    }

    void UpdateEnemiesRemainingText()
    {
        enemiesRemainingText.text = "Enemies Remaining: " + enemiesRemaining;
    }
}
