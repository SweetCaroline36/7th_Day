using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class ChangeImage : MonoBehaviour
{
    [SerializeField] public Sprite normal, mute;
    [SerializeField] private bool music, sfx;
    private bool muted;

    // Start is called before the first frame update
    void Start()
    {
        if (music)
        {
            muted = AudioManager.Instance.getLastMusicState();
            if (!muted)
                gameObject.GetComponentInChildren<UnityEngine.UI.Image>().sprite = normal;
            else
                gameObject.GetComponentInChildren<UnityEngine.UI.Image>().sprite = mute;
        }
        else if (sfx)
        {
            muted = AudioManager.Instance.getLastSFXState();
            if (!muted)
                gameObject.GetComponentInChildren<UnityEngine.UI.Image>().sprite = normal;
            else
                gameObject.GetComponentInChildren<UnityEngine.UI.Image>().sprite = mute;
        }
    }

    public void ToggleImage()
    {
        if (!muted)
        {
            gameObject.GetComponentInChildren<UnityEngine.UI.Image>().sprite = mute;
            muted = true;

        }
        else
        {
            gameObject.GetComponentInChildren<UnityEngine.UI.Image>().sprite = normal;
            muted = false;
        }
    }
}
