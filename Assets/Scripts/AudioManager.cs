using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource efxSource;
    public AudioSource musicSource;

    [Header("Background Music")]
    public AudioClip menuMusic;
    public AudioClip gameMusic;

    [Header("Sound Effects")]
    public AudioClip buttonClick;
    public AudioClip gameOver;
    public AudioClip pickColor;

    private bool isMuted; // Chỉ 1 biến quản lý tất cả

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        isMuted = PlayerPrefs.GetInt("Muted", 0) == 1;
        PlayMusic(menuMusic);
    }

    public void PlayMusic(AudioClip clip)
    {
        if (!isMuted && clip != null)
        {
            musicSource.clip = clip;
            if (!musicSource.isPlaying)
            {
                musicSource.Play();
            }
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

    public void PlayEffects(AudioClip clip)
    {
        if (!isMuted && clip != null)
        {
            efxSource.PlayOneShot(clip);
        }
    }

    // Gộp mute music + efx thành 1
    public void ToggleMute()
    {
        isMuted = !isMuted;

        if (isMuted)
        {
            StopMusic();
            musicSource.mute = true;
            efxSource.mute = true;
        }
        else
        {
            musicSource.mute = false;
            efxSource.mute = false;
            PlayMusic(menuMusic);
        }

        PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
    }

    public bool IsMuted()
    {
        return isMuted;
    }
}
