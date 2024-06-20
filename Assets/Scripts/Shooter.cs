using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectilePrefab; // Drag your projectile prefab here
    public Vector3 spawnPosition; // The position where the projectile will spawn
    public float spawnInterval = 3f; // Time interval between each spawn

    private float timeSinceLastSpawn;

    void Start()
    {
        timeSinceLastSpawn = spawnInterval;
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnProjectile();
            timeSinceLastSpawn = 0f;
        }
    }

    void SpawnProjectile()
    {
        Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);
    }
}