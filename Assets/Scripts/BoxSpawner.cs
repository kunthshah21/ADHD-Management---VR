using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [Header("References")]
    public GameObject planeObject;  // Drag your FloorPlane here
    public GameObject boxPrefab;    // Drag your box (cube) prefab here

    [Header("Spawner Settings")]
    // Time interval between box spawns
    public float spawnInterval = 2f;

    // We'll store the plane's bounds here
    private Bounds planeBounds;
    // Simple timer for spawn intervals
    private float timer = 0f;

    private void Start()
    {
        // Get the Renderer on the plane so we can read its bounding box
        Renderer planeRenderer = planeObject.GetComponent<Renderer>();
        planeBounds = planeRenderer.bounds;

        // Optional: log the size of the plane for debugging
        Debug.Log("Plane bounds: " + planeBounds);
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnBoxOnPlane();
            timer = 0f;
        }
    }

    private void SpawnBoxOnPlane()
    {
        // Extract the min/max X and Z from the plane's bounds
        float minX = planeBounds.min.x;
        float maxX = planeBounds.max.x;
        float minZ = planeBounds.min.z;
        float maxZ = planeBounds.max.z;

        // Randomly pick a point within those bounds
        float randomX = Random.Range(minX, maxX);
        float randomZ = Random.Range(minZ, maxZ);

        // We assume the plane is at roughly a single Y-position (flat).
        // You can do planeBounds.center.y or planeBounds.max.y.
        // If your plane is at y=0, either is typically the same.
        float spawnY = planeBounds.max.y;

        // Final spawn position
        Vector3 spawnPosition = new Vector3(randomX, spawnY, randomZ);

        // Instantiate the box at that position
        Instantiate(boxPrefab, spawnPosition, Quaternion.identity);

        // (Optional) Debug log
        Debug.Log("Spawned box at " + spawnPosition);
    }
}
