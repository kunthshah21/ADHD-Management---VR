using UnityEngine;
using UnityEngine.UI;

public class InputPopupTimer : MonoBehaviour
{
    public float timerDuration = 10f; // time in seconds before showing input
    public GameObject inputPanel; // assign your input UI panel here

    private float timer;
    private bool hasActivated = false;

    void Start()
    {
        timer = timerDuration;

        if (inputPanel != null)
            inputPanel.SetActive(false); // start hidden
    }

    void Update()
    {
        if (hasActivated) return;

        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            ActivateInput();
            hasActivated = true;
        }
    }

    void ActivateInput()
    {
        if (inputPanel != null)
        {
            inputPanel.SetActive(true);

            // Focus the input field (if any)
            InputField input = inputPanel.GetComponentInChildren<InputField>();
            if (input != null)
                input.Select();
        }
    }
}
