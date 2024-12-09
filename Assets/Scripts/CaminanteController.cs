using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CaminanteController : MonoBehaviour
{
    Animator animator; // Assign your Animator component
    NavMeshAgent agent;
    Transform player;

    public float attackRange = 2.0f; // Distance to start attacking
    public float health = 100f;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        player = FindObjectOfType<PlayerMovementScript>().transform;


        
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = player.position;
        
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= attackRange)
        {
            // Start attacking
            agent.isStopped = true;
            animator.SetBool("isWalking", false);
            animator.SetBool("isAtackign", true);
        }
        else
        {
            // Start walking
            agent.isStopped = false;
            agent.SetDestination(player.position);
            animator.SetBool("isWalking", true);
            animator.SetBool("isAtackign", false);
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
        animator.SetBool("isWalking", false);
        animator.SetBool("isAtackign", false);
        animator.SetBool("sDead", true);

        // Optional: Destroy zombie after animation ends
        Destroy(gameObject, 3f); // Adjust time as needed
    }
}
