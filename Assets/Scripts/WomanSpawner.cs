using UnityEngine;
using System.Collections;

public class WomanSpawner : MonoBehaviour
{
    // Drag your woman prefab into this slot in the Inspector
    public GameObject womanPrefab;

    // Assign the spawn transform in the Inspector
    public Transform spawnPoint; // Set this to (3.89, 0, -4.7)
    
    [Range(0f, 1f)]
    public float spawnProbability = 0.3f; // 30% chance to spawn when the timer expires
    
    public float minSpawnDelay = 10f; // Increased minimum delay
    public float maxSpawnDelay = 20f; // Increased maximum delay

    private void Start()
    {
        // Start the coroutine to spawn women repeatedly
        StartCoroutine(SpawnWomanRoutine());
    }

    public IEnumerator SpawnWomanRoutine()
    {
        while (true)
        {
            // Wait for a random delay between spawns
            float delay = Random.Range(minSpawnDelay, maxSpawnDelay);
            yield return new WaitForSeconds(delay);

            // Only spawn if random check passes
            if (Random.value < spawnProbability)
            {
                // Instantiate the woman prefab at the spawn point
                Instantiate(womanPrefab, spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}