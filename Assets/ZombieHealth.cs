using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    public float health = 100f; // Salud del zombie

    // Método para recibir daño
    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die(); // Si la salud llega a 0, el zombie muere
        }
    }

    // Método que maneja la muerte del zombie
    private void Die()
    {
        Debug.Log("Zombie muerto");
        Destroy(gameObject); // Destruye al zombie
    }
}
