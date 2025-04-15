using UnityEngine;

public class WomanController : MonoBehaviour
{
    public float speed = 1.5f; // Walking speed
    private Animator animator;
    private Renderer objectRenderer;

    private void Start()
    {
        // Get the Animator component
        animator = GetComponent<Animator>();
        if (animator != null)
        {
            animator.SetBool("isWalking", true); // Start walking animation
        }

        // Get the Renderer component to check visibility
        objectRenderer = GetComponentInChildren<Renderer>(); // Use InChildren in case mesh is nested
    }

    private void Update()
    {
        // Move forward in the direction the object is facing
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
        // Check if the object is still visible to any camera
        if (objectRenderer != null && !objectRenderer.isVisible)
        {
            Destroy(gameObject);
        }
    }
}
