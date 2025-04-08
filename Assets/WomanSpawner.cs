using UnityEngine;
using System.Collections;

public class WomanSpawner : MonoBehaviour
{
    // Drag your woman prefab into this slot in the Inspector
    public GameObject womanPrefab;

    // Assign the spawn transform in the Inspector
    public Transform spawnPoint; // Set this to (3.89, 0, -4.7)

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
            float delay = Random.Range(5f, 10f);
            yield return new WaitForSeconds(delay);

            // Instantiate the woman prefab at the spawn point
            Instantiate(womanPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
