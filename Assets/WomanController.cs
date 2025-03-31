using UnityEngine;

public class WomanController : MonoBehaviour
{
    // Public field to assign the destination in the inspector (or via another script)
    public Transform destination;
    public float speed = 1.5f; // Adjust this for desired walking speed

    private Animator animator;

    private void Start()
    {
        // Get the Animator component on the prefab
        animator = GetComponent<Animator>();

        // Start the walking animation.
        // If using a boolean parameter:
        if (animator != null)
        {
            animator.SetBool("isWalking", true);
        }
        // Alternatively, if your animator uses a trigger called "Walk":
        // animator.SetTrigger("Walk");
    }

    private void Update()
    {
        // If a destination is set, move towards it
        if (destination != null)
        {
            // Move the woman toward the destination at the defined speed
            transform.position = Vector3.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);

            // Optionally, you could rotate her to face the destination:
            Vector3 direction = destination.position - transform.position;
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
            }
        }
    }
}
