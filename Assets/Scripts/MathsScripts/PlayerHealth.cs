using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5;
    public int currentHealth;

    public TextMeshProUGUI healthText; // Text component for displaying health on UI
    public GameObject gameOverPanel; // UI panel for game over screen
    private GameManager gameManager;

    public void Start()
    {
        // Initialize health
        currentHealth = maxHealth;
        gameManager = FindObjectOfType<GameManager>(); // Find GameManager in the scene
        healthText.text = "Health : " + currentHealth.ToString();
        UpdateHealthUI();
    }

    // Call this method when the player takes damage
    public void TakeDamage()
    {
        currentHealth--;

        Debug.Log("Player took damage! Current health: " + currentHealth);
        UpdateHealthUI(); // Update health display on the UI

        if (currentHealth <= 0)
        {
            GameOver(); // Trigger game over
        }
    }

    // Update the health display text
    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health : " + currentHealth.ToString();
        }

        // Update health in GameManager
        if (gameManager != null)
        {
            gameManager.health = currentHealth; // Sync health with GameManager
        }
    }

    // Trigger game over state
    void GameOver()
    {
        Debug.Log("Game Over!");

        // Show game over panel
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);

        // Freeze the game
        Time.timeScale = 0f;
    }

    // Reset the health back to max health
    public void ResetHealth()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
        Time.timeScale = 1f; // Resume the game
    }
}