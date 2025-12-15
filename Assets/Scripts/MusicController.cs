using UnityEngine;

// Ensures that any GameObject this script is attached to also has an AudioSource component.
[RequireComponent(typeof(AudioSource))]
public class MusicController : MonoBehaviour
{
    // Public variable for the main game background music. 
    // Drag your "Barney - Theme Song..." MP3 file here in the Inspector.
    public AudioClip backgroundMusicClip;

    // Public variable for the 'Game Over' or 'Death' sound/music.
    // Drag your transition sound file here in the Inspector.
    public AudioClip deathMusicClip;

    private AudioSource audioSource;

    void Awake()
    {
        // Get the required AudioSource component attached to this GameObject.
        audioSource = GetComponent<AudioSource>();

        // Safety check
        if (audioSource == null)
        {
            Debug.LogError("MusicController is missing a required AudioSource component!");
            enabled = false;
            return;
        }

        // Set the initial clip and loop status for the background music.
        audioSource.clip = backgroundMusicClip;
        audioSource.loop = true;
    }

    void Start()
    {
        // Start playing the background music when the scene loads.
        if (audioSource.clip != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Error: Background Music Clip is not assigned in the Inspector!");
        }
    }

    /// <summary>
    /// This public method should be called by your GameManager or Player script 
    /// (e.g., when the player runs out of health or hits a hazard).
    /// It stops the current music and starts the death music clip.
    /// </summary>
    public void PlayDeathMusic()
    {
        // Stop the current playing music immediately
        audioSource.Stop();

        if (deathMusicClip != null)
        {
            // 1. Assign the new 'death' clip
            audioSource.clip = deathMusicClip;

            // 2. The death music usually only plays once
            audioSource.loop = false;

            // 3. Play the death clip
            audioSource.Play();

            Debug.Log("Background music stopped. Playing Death/Game Over music.");
        }
        else
        {
            Debug.LogWarning("Death Music Clip is not assigned. Music simply stopped.");
        }
    }
}