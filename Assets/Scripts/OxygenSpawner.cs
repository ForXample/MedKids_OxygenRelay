using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenSpawner : MonoBehaviour
{
    public GameObject greenShapePrefab;
    public float spawnInterval = 3.0f;
    public int shapesPerSpawn = 3; // Number of shapes to spawn each interval
    public Vector2 spawnZoneSize = new Vector2(5.0f, 2.0f); // Size of the spawn zone (width x height)
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
            for (int i = 0; i < shapesPerSpawn; i++)
            {
                SpawnShape();
            }
            timer = spawnInterval;
        }
    }

    void SpawnShape()
    {
        // Randomize position within the spawn zone
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnZoneSize.x / 2, spawnZoneSize.x / 2),
            Random.Range(-spawnZoneSize.y / 2, spawnZoneSize.y / 2),
            0);

        // Convert local position to world position
        spawnPosition = transform.TransformPoint(spawnPosition);

        Instantiate(greenShapePrefab, spawnPosition, Quaternion.identity);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnZoneSize.x, spawnZoneSize.y, 1));
    }
}

