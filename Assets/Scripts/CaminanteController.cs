using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CaminanteController : MonoBehaviour
{
    public float maxHealth = 50f;  // Salud máxima del zombie
    private float currentHealth;   // Salud actual del zombie

    Animator anim;
    NavMeshAgent agent;
    Transform player;
    bool Attacking;
    public float AttackDistance = 2f;
    public string AttackAnimation;
    public float AttackTransition = 0.1f;
    public float AttackDuration = 2f;

    void Start()
    {
        currentHealth = maxHealth;  // Inicializa la salud del zombie
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerMovementScript>().transform;
    }

    void Update()
    {
        if (!Attacking)
        {
            agent.destination = player.position;
            anim.SetFloat("Speed", agent.velocity.magnitude / agent.speed);

            if (Vector3.Distance(player.position, transform.position) <= agent.stoppingDistance)
            {
                StartCoroutine(CrossToAttackLayer());
            }
        }
    }

    IEnumerator CrossToAttackLayer()
    {
        agent.isStopped = true;
        Attacking = true;

        float d = 0f;
        while (d < AttackTransition)
        {
            d += Time.deltaTime;
            anim.SetLayerWeight(1, d * 1f / AttackTransition);
            yield return null;
        }

        anim.CrossFade(AttackAnimation, 0.1f);
        yield return new WaitForSeconds(AttackDuration);
        anim.SetLayerWeight(1, 0f);
        Attacking = false;
    }

    // Función para que el zombie reciba daño
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Función para matar al zombie
    private void Die()
    {
        // Aquí puedes poner la animación de muerte y desactivar el zombie
        anim.SetTrigger("Die");
        agent.enabled = false;
        // Puedes destruir el zombie después de un pequeño retraso si lo deseas
        Destroy(gameObject, 2f);
    }
}
