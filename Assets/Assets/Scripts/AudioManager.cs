using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource musicSource;
    public AudioSource sfxSource;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.Log("Duplicate AudioManager destroyed.");
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        musicSource.Play();
    }

    public void PlaySfx(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
        Debug.Log("SFX played: " + clip.name);
    }

    public void ChangeMusicVolume(float amount)
    {
        musicSource.volume = Mathf.Clamp01(musicSource.volume + amount);
        Debug.Log("Music volume: " + musicSource.volume.ToString("F1"));
    }
}
