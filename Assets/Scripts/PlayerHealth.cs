using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Max health of the player
    public float currentHealth;   // Current health of the player
    public Slider healthBar;      // UI slider for health bar

    void Start()
    {
        currentHealth = maxHealth; // Initialize with full health
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }

        UpdateHealthBar();
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth; // Cap health at max value
        }

        UpdateHealthBar();
    }

    void Die()
    {
        SceneManager.LoadScene("Menu"); // Replace with your menu scene name
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth / maxHealth; // Normalize health to 0-1 for the slider
        }
    }
}
