using UnityEngine;

public class AudioManagement : MonoBehaviour
{ 
    public static AudioManagement Instance {  get; private set; }


    [Header("---------- Audio Source ----------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("---------- Audio Source ----------")]
    public AudioClip background;
    public AudioClip Door;
    public AudioClip Coins;
    public AudioClip SpeechBubbleReview;
    public AudioClip Taskboard;
    


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;

        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    private void Start()
    {
        if (musicSource != null && background != null)
        {
            musicSource.clip = background;
            musicSource.loop = true;
            musicSource.Play();

        }

    }


    public void PlaySFX(AudioClip clip)
    {
        
        if (SFXSource == null || clip == null) return;
        SFXSource.PlayOneShot(clip);

    }

    public void StopMusic()
    {
       
        if (musicSource == null) return;
        musicSource.Stop();

    }

    public void SetMusicMuted(bool mute)
    {

        if (musicSource == null) return;
        musicSource.mute = mute;

    }
}

