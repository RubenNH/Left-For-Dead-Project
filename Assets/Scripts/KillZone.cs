using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    public Transform respawnPoint; // Assign the respawn position in the Inspector

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player entered the kill zone
        if (other.CompareTag("Player"))
        {
            // Move the player to the respawn point
            other.transform.position = respawnPoint.position;

        }
    }
}

