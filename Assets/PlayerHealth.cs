using UnityEngine;
using UnityEngine.UI; // Asegúrate de incluir esta librería para trabajar con el Slider

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBar;  // Referencia al Slider (barra de vida)
    public float maxHealth = 100f;
    private float currentHealth;

    void Start()
    {
        // Inicializa la salud
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    // Actualiza el valor del Slider con la salud actual
    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            // Asigna el valor del Slider con la proporción de la salud actual
            healthBar.value = currentHealth / maxHealth;
        }
    }

    // Función para aplicar daño al jugador
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHealthBar();
    }

    // Función para curar al jugador
    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        UpdateHealthBar();
    }

    // Opcional: Función para obtener la salud actual
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
