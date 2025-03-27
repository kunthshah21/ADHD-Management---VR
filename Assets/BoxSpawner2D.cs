using UnityEngine;

public class BoxSpawner2D : MonoBehaviour
{
    [Header("References")]
    public GameObject backgroundCube;  // The cube on which we spawn boxes (negative X face)
    public GameObject boxPrefab;       // Box prefab to spawn

    [Header("Random Spawn Timing")]
    private float spawnInterval; 
    private float timer = 0f;

    // We'll store the cube's bounding box for positioning
    private Bounds cubeBounds;

    // Track total boxes spawned (accessible from GameManager)
    public static int totalBoxesSpawned = 0;

    // Whether the spawner is allowed to spawn boxes
    public bool gameActive = false;

    private void Start()
    {
        // Get the bounding box of the cube
        Renderer cubeRenderer = backgroundCube.GetComponent<Renderer>();
        if (cubeRenderer != null)
        {
            cubeBounds = cubeRenderer.bounds;
        }
        else
        {
            Debug.LogWarning("No Renderer found on backgroundCube!");
        }

        // Initially pick a random spawn interval between 1 and 5
        spawnInterval = Random.Range(1f, 5f);
    }

    private void Update()
    {
        if (!gameActive)
            return;  // Do not spawn if the game is not active

        timer += Time.deltaTime;
        // Spawn a box once we exceed the spawnInterval
        if (timer >= spawnInterval)
        {
            SpawnBoxOnNegativeXFace();
            timer = 0f;

            // After spawning, pick a new random interval
            spawnInterval = Random.Range(1f, 5f);
        }
    }

    private void SpawnBoxOnNegativeXFace()
    {
        if (backgroundCube == null || boxPrefab == null)
        {
            Debug.LogWarning("Missing references for spawning!");
            return;
        }

        // Fix x at the negative X face
        float spawnX = cubeBounds.min.x;

        // Randomize Y, Z within the cube's bounds
        float randomY = Random.Range(cubeBounds.min.y, cubeBounds.max.y);
        float randomZ = Random.Range(cubeBounds.min.z, cubeBounds.max.z);

        Vector3 spawnPos = new Vector3(spawnX, randomY, randomZ);

        // Instantiate the box
        GameObject newBox = Instantiate(boxPrefab, spawnPos, Quaternion.identity);

        // Randomly destroy after 0.2–0.5 seconds
        float destroyTime = Random.Range(0.2f, 0.5f);
        Destroy(newBox, destroyTime);

        // Increment total spawned
        totalBoxesSpawned++;
    }

    // Optionally, you could add a ResetScore() if you want to clear totalBoxesSpawned when needed
    public static void ResetScore()
    {
        totalBoxesSpawned = 0;
    }
}
