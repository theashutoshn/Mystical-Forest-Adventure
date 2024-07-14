using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip reelSpinClip;
    public AudioClip reelStopClip;

    private AudioSource audioSource;

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
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayReelSpin()
    {
        audioSource.clip = reelSpinClip;
        audioSource.Play();
    }

    public void PlayReelStop()
    {
        audioSource.clip = reelStopClip;
        audioSource.Play();
    }
}
