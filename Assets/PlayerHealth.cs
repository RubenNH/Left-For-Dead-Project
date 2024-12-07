using UnityEngine;
using UnityEngine.UI; // Aseg�rate de incluir esta librer�a para trabajar con el Slider

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
            // Asigna el valor del Slider con la proporci�n de la salud actual
            healthBar.value = currentHealth / maxHealth;
        }
    }

    // Funci�n para aplicar da�o al jugador
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHealthBar();
    }

    // Funci�n para curar al jugador
    public void Heal(float amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;

        UpdateHealthBar();
    }

    // Opcional: Funci�n para obtener la salud actual
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
}
