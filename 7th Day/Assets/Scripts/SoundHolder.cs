using UnityEngine;

public class SoundHolder : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioClip[] clips;

    public void playClip()
    {
        AudioManager.Instance.PlayClip(clip);
    }

    public void playRandomClip()
    {
        int randomIndex = Random.Range(0, clips.Length);
        print(randomIndex);
        AudioManager.Instance.PlayClip(clips[randomIndex]);
    }
}
