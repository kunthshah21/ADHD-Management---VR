using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip backgroundMusic; // Assign office.mp3 in the inspector
    private AudioSource audioSource;
    
    // Singleton pattern to ensure the audio continues between scenes if needed
    private static AudioManager instance;
    
    private void Awake()
    {
        // Singleton pattern implementation
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        // Get or add AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
        
        // Configure the audio source
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.playOnAwake = true;
        audioSource.volume = 0.5f; // Adjust as needed
        
        // Start playing
        audioSource.Play();
    }
}