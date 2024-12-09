using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab; // Assign the zombie prefab in the Inspector
    public List<Transform> spawnZones; // Add spawn zones in the Inspector
    public int maxZombies = 40;
    private int currentZombieCount = 0;

    public float spawnInterval = 3f; // Time between spawns

    void Start()
    {
        spawnZones = new List<Transform>();
        GameObject[] zones = GameObject.FindGameObjectsWithTag("SpawnZone");
        foreach (GameObject zone in zones)
        {
            spawnZones.Add(zone.transform);
        }
        // Start spawning zombies periodically
        InvokeRepeating(nameof(SpawnZombies), 0f, spawnInterval);
    }

    void SpawnZombies()
    {
        // Check if we can spawn more zombies
        if (currentZombieCount >= maxZombies) return;

        // Randomly pick a spawn zone
        Transform spawnZone = spawnZones[Random.Range(0, spawnZones.Count)];

        //ramdomly spawn into 3 to 5 zombies
        int randomZombie = Random.Range(3, 6);
        for (int i = 0; i < randomZombie; i++)
        {
            Instantiate(zombiePrefab, spawnZone.position, spawnZone.rotation);
        }

        currentZombieCount += randomZombie;
    }

    public void ZombieKilled()
    {
        // Decrease the zombie count when a zombie is killed
        currentZombieCount = Mathf.Max(0, currentZombieCount - 1);
    }
}