using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource musicSource, effectSource;
    private static bool mutedMusic, mutedEffect;
    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool getLastMusicState()
    {
        return mutedMusic;
    }

    public void setLastMusicState(bool newState)
    {
        mutedMusic = newState;
    }

    public bool getLastSFXState()
    {
        return mutedEffect;
    }

    public void setLastSFXState(bool newState)
    {
        mutedEffect = newState;
    }

    public void PlayClip(AudioClip clip)
    {
        effectSource.PlayOneShot(clip);
    }

    public void PlayDialogue(AudioClip clip)
    {
        effectSource.clip = clip;
        effectSource.Play();
    }
    public void StopDialogue()
    {
        effectSource.Stop();
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
        mutedMusic = !mutedMusic;
    }

    public void ToggleSFX()
    {
        effectSource.mute = !effectSource.mute;
        mutedEffect = !mutedEffect;
    }
}
