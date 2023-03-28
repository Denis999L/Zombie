using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 100;

    public HealthBar healthBar;

    public Canvas gameOverCanvas;
    private bool isGameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        if (!isGameOver)
        {
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                GameOver();
            }
        }
    }

    private void GameOver()
    {
        isGameOver = true;

        // Set the game over canvas to active and pause the game
        gameOverCanvas.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
