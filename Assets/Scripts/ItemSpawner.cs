using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject minePrefab;
    public GameObject cratePrefab;
    public Vector3 spawnAreaSize;
    public float itemDisappearTime = 10f; // Common disappear time for both crates and mines
    public float minDistanceToPlayer = 2f; // Minimum distance from player for spawn

    private GameObject player; // Reference to the player GameObject

    private void Start()
    {
        // Find the player GameObject
        player = GameObject.FindGameObjectWithTag("Player");

        // Start spawning objects
        InvokeRepeating("SpawnObject", 0f, 3f); // Change the second parameter to adjust spawn interval
    }

    private void SpawnObject()
    {
        // Calculate random position within spawn area
        Vector3 spawnPosition = CalculateSpawnPosition();

        // Randomly choose between mine and crate
        GameObject objectToSpawn = Random.value < 0.5f ? minePrefab : cratePrefab;

        // Spawn the object
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        // Schedule the object to disappear after the specified time
        Destroy(spawnedObject, itemDisappearTime);
    }

    private Vector3 CalculateSpawnPosition()
    {
        Vector3 spawnPosition = Vector3.zero;
        bool positionValid = false;

        // Continue trying new positions until a valid one is found
        while (!positionValid)
        {
            // Calculate random position within spawn area
            spawnPosition = transform.position + new Vector3(Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
                                                              0f,
                                                              Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2));

            // Check if the spawn position is too close to the player
            if (Vector3.Distance(spawnPosition, player.transform.position) >= minDistanceToPlayer)
            {
                // Check if the spawn position intersects with any objects tagged as "wall"
                Collider[] colliders = Physics.OverlapBox(spawnPosition, new Vector3(0.5f, 0.5f, 0.5f)); // Adjust box size as needed
                bool intersectsWall = false;
                foreach (Collider collider in colliders)
                {
                    if (collider.CompareTag("Wall"))
                    {
                        intersectsWall = true;
                        break;
                    }
                }

                // If the spawn position does not intersect with any walls, mark it as valid
                if (!intersectsWall)
                {
                    positionValid = true;
                }
            }
        }

        return spawnPosition;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, spawnAreaSize);
    }
}
