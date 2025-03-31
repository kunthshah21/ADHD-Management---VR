using UnityEngine;
using UnityEngine.SceneManagement; // Only if you need scene reloading
using System.Collections;
using TMPro;                      // TextMeshPro namespace

public class GameManager : MonoBehaviour
{
    [Header("References")]
    public BoxSpawner2D spawner; // Drag your BoxSpawner2D object here

    [Header("UI Elements")]
    public TMP_Text countdownText;   // For "3,2,1" countdown
    public TMP_Text resultText;      // Displays final result
    public GameObject guessPanel;    // Panel with InputField & Submit button
    public TMP_InputField guessInput; // The TextMeshPro InputField for user’s guess

    [Header("Game Settings")]
    public float gameDuration = 60f; // 60 seconds

    private bool gameStarted = false;

    private void Start()
    {
        // Hide the guess panel at the start
        guessPanel.SetActive(false);

         resultText.text = ""; // Clear the result text

        // Reset the box count
        BoxSpawner2D.ResetScore();

        // Begin the countdown
        StartCoroutine(StartCountdown());

        // After the countdown finishes
        WomanSpawner womanSpawner = FindObjectOfType<WomanSpawner>();
        if (womanSpawner != null)
        {
            StartCoroutine(womanSpawner.SpawnWomanRoutine());
        }

    }

    private IEnumerator StartCountdown()
    {
        // Show "3"
        countdownText.gameObject.SetActive(true);
        countdownText.text = "3";
        yield return new WaitForSeconds(1f);

        // Show "2"
        countdownText.text = "2";
        yield return new WaitForSeconds(1f);

        // Show "1"
        countdownText.text = "1";
        yield return new WaitForSeconds(1f);

        // Hide the countdown text
        countdownText.gameObject.SetActive(false);

        // Start the spawning logic
        gameStarted = true;
        spawner.gameActive = true;

        // Wait for 60 seconds
        yield return new WaitForSeconds(gameDuration);

        // Stop spawning boxes
        spawner.gameActive = false;

        // Show the guess panel
        guessPanel.SetActive(true);
    }

    // Called by the Submit button on the guess panel
    public void OnSubmitGuess()
    {
        int userGuess;
        // Try to parse user input
        if (int.TryParse(guessInput.text, out userGuess))
        {
            // Compare with actual spawned boxes
            int actual = BoxSpawner2D.totalBoxesSpawned;
            if (userGuess == actual)
            {
                resultText.text = "Your score is 100.";
            }
            else
            {
                float difference = Mathf.Abs((userGuess - actual) / (float)actual) * 100f;
                resultText.text = $"You were off by {difference:F2}%";
            }
        }
        else
        {
            // Invalid integer input
            resultText.text = "Please enter a valid number.";
        }
    }
}
