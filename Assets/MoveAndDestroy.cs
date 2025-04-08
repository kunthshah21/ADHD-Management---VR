using UnityEngine;

public class MoveAndDestroyWithAnimation : MonoBehaviour
{
    public float speed = 2f; // Movement speed

    private Renderer objectRenderer;
    private Animator animator;

    private void Start()
    {
        // Get the Renderer component from self or child
        objectRenderer = GetComponentInChildren<Renderer>();

        // Get the Animator component
        animator = GetComponent<Animator>();

        // Start the walking animation (assumes a bool parameter called "isWalking")
        if (animator != null)
        {
            animator.SetBool("isWalking", true);
        }
    }

    private void Update()
    {
        // Move the object forward every frame
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Destroy if no longer visible to any camera
        if (objectRenderer != null && !objectRenderer.isVisible)
        {
            Destroy(gameObject);
        }
    }
}
