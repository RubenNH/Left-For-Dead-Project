using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float bulletLifetime = 5f; // Tiempo de vida de la bala antes de destruirse
    public int damage = 10; // Daño que inflige la bala
    public float speed = 20f; // Velocidad de la bala

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Si tiene Rigidbody, lanzamos la bala al frente
        if (rb != null)
        {
            rb.velocity = transform.forward * speed;
        }

        // Destruir la bala después de un tiempo
        Destroy(gameObject, bulletLifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detecta si la bala colisiona con un objeto (zombie, paredes, etc.)
        if (other.CompareTag("Zombie"))
        {
            // Infligir daño al zombie
            ZombieHealth zombieHealth = other.GetComponent<ZombieHealth>();
            if (zombieHealth != null)
            {
                zombieHealth.TakeDamage(damage);
            }

            // Destruir la bala
            Destroy(gameObject);
        }
        else if (other.CompareTag("Wall"))
        {
            // Si choca con una pared, destruir la bala
            Destroy(gameObject);
        }
    }
}
