using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CaminanteController : MonoBehaviour
{
    Animator animator; // Assign your Animator component
    NavMeshAgent agent;
    Transform player;

    public float attackRange = 0.8f; // Distance to start attacking
    public float health = 30f;
    private bool isDead = false;
    public float attackCooldown = 0.3f; // Time between attacks
    private float attackTimer; // Tracks time since last attack

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.radius = 0.5f;  // Adjust as needed
        agent.avoidancePriority = Random.Range(1, 100); 
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMovementScript>().transform;
        attackTimer = attackCooldown; // Initialize timer
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead) return;

        Vector3 randomOffset = new Vector3(Random.Range(-2f, 2f), 0, Random.Range(-2f, 2f));
        Vector3 targetPosition = player.position + randomOffset;
        agent.SetDestination(targetPosition);
        
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange && !isDead)
        {
            // Start attacking
            agent.isStopped = true;
            if (attackTimer <= 0f)
            {
                Attack();
                attackTimer = attackCooldown; // Reset cooldown
            }
        }
        else
        {
            // Start walking
            agent.isStopped = false;
            agent.SetDestination(player.position);
            animator.SetBool("isWalking", true);
            animator.SetBool("isAtackign", false);
        }
        
        attackTimer -= Time.deltaTime;
    }
    
    void Attack()
    {
        animator.SetBool("isAtackign", true);
        animator.SetBool("isWalking", false);

        // Deal damage to the player after attack animation starts
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(3f); // Adjust damage as needed
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0 && !isDead)
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        agent.isStopped = true; // Stop moving
        animator.SetBool("sDead", true);
        animator.SetBool("isWalking", false);
        animator.SetBool("isAtackign", false);
        Destroy(gameObject, 3f); // Adjust time as needed
        
        ZombieSpawner spawner = FindObjectOfType<ZombieSpawner>();
        if (spawner != null)
        {
            spawner.ZombieKilled();
        }
    }
}
