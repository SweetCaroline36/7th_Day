using UnityEngine;

public class MusicHolder : MonoBehaviour
{
    [SerializeField] private AudioClip menuMusic, gameMusic;

    public void playGameMusic()
    {
        AudioManager.Instance.PlayMusic(gameMusic);
    }
}