using UnityEngine;
using System.Collections;

public class WomanSpawner : MonoBehaviour
{
    // Drag your woman prefab into this slot in the Inspector
    public GameObject womanPrefab;
    
    // Assign the spawn and destination transforms in the Inspector
    public Transform spawnPoint;         // Should be set to (3.89, 0, -4.7)
    public Transform destinationPoint;   // Should be set to (2.5, 0, -3.73)

    private void Start()
    {
        // Start the coroutine to spawn the woman after a random delay
        StartCoroutine(SpawnWomanRoutine());
    }

    public IEnumerator SpawnWomanRoutine()
    {
        // Wait for a random delay between 5 and 10 seconds
        float delay = Random.Range(5f, 10f);
        yield return new WaitForSeconds(delay);

        // Instantiate the woman prefab at the spawn point
        GameObject woman = Instantiate(womanPrefab, spawnPoint.position, spawnPoint.rotation);

        // Set the destination on the WomanController attached to the prefab
        WomanController controller = woman.GetComponent<WomanController>();
        if (controller != null)
        {
            controller.destination = destinationPoint;
        }
    }
}
