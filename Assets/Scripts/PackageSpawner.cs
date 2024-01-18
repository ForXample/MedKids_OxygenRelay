using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PackageSpawner : MonoBehaviour
{
    public GameObject packagePrefab;
    public float spawnInterval = 5.0f;
    public float spawnRadius = 2.0f; // Radius around the spawner where packages can appear
    private float timer;

    void Start()
    {
        timer = spawnInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            SpawnPackage();
            timer = spawnInterval;
        }
    }

    void SpawnPackage()
    {
        // Spawn the package at a random point within the spawn radius
        Vector3 spawnPosition = transform.position + Random.insideUnitSphere * spawnRadius;
        spawnPosition.z = 0; // Ensure the package spawns in the correct plane

        Instantiate(packagePrefab, spawnPosition, Quaternion.identity);
    }
}

