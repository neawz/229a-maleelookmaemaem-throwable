using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Clips")]
    public AudioClip musicClip;
    public AudioClip clickClip;
    public AudioClip spinClip;
    public AudioClip fallClip;
    public AudioClip resultClip;
    public AudioClip windClip;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource SFXSource;
    public AudioSource loopSource; 

    private static AudioManager instance;
    public static AudioManager GetInstance()
    {
        return instance;
    }

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void Start()
    {
        PlayMusic();
    }
    public void PlayMusic()
    {
        musicSource.clip = musicClip;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayClick() => PlaySFX(clickClip);
    public void PlayFall() => PlaySFX(fallClip);
    public void PlayResult() => PlaySFX(resultClip);

    
    public void PlaySpinLoop()
    {
        if (spinClip == null || SFXSource == null) return;
        if (SFXSource.clip == spinClip && SFXSource.isPlaying && SFXSource.loop) return;

        SFXSource.clip = spinClip;
        SFXSource.loop = true;
        SFXSource.Play();
    }

    public void StopSpin()
    {
        if (SFXSource == null) return;
        if (SFXSource.clip == spinClip)
        {
            SFXSource.Stop();
            SFXSource.loop = false;
            SFXSource.clip = null;
        }
    }

    
    public void PlayWindLoop()
    {
        if (windClip == null || loopSource == null) return;
        if (loopSource.clip == windClip && loopSource.isPlaying && loopSource.loop) return;

        loopSource.clip = windClip;
        loopSource.loop = true;
        loopSource.Play();
    }

    public void StopWind()
    {
        if (loopSource == null) return;
        if (loopSource.clip == windClip)
        {
            loopSource.Stop();
            loopSource.loop = false;
            loopSource.clip = null;
        }
    }
}
