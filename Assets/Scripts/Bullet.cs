using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float damage = 10f;
    public GameObject impactEffect;  // Efecto de impacto, puede ser una pequeña explosión o chispas.

    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = transform.forward * speed;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie")) // Asegúrate de que los zombies tienen el tag "Zombie"
        {
            // Aquí se le aplica daño al zombie
            ZombieHealth zombieHealth = collision.gameObject.GetComponent<ZombieHealth>();
            if (zombieHealth != null)
            {
                zombieHealth.TakeDamage(damage);  // Método que resta vida al zombie
            }
        }

        // Crear efecto de impacto
        if (impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);  // Destruir la bala después del impacto
    }
}
