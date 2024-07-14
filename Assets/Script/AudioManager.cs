using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip reelSpinClip;
    public AudioClip reelStopClip;
    public AudioClip generalButtonClip;
    public AudioClip backgroundMusicClip;

    private AudioSource musicAudioSource; // AudioSource for background music
    private AudioSource effectsAudioSource; // AudioSource for sound effects

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Add two AudioSource components to the game object
        musicAudioSource = gameObject.AddComponent<AudioSource>();
        effectsAudioSource = gameObject.AddComponent<AudioSource>();

        // Play background music
        PlayBackgroundMusic();
    }

    public void PlayReelSpin()
    {
        effectsAudioSource.PlayOneShot(reelSpinClip);
        effectsAudioSource.loop = true;
    }

    public void PlayReelStop()
    {
        effectsAudioSource.PlayOneShot(reelStopClip);
    }

    public void PlayGeneralButtonSound()
    {
        effectsAudioSource.PlayOneShot(generalButtonClip);
    }

    public void PlayBackgroundMusic()
    {
        musicAudioSource.clip = backgroundMusicClip;
        musicAudioSource.loop = true; // Set the audio to loop
        musicAudioSource.Play();
    }
}
