using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleAudio : MonoBehaviour
{
    [SerializeField] private bool toggleMusic, toggleSFX;
    // Start is called before the first frame update
    public void Toggle()
    {
        if (toggleMusic)
        {
            AudioManager.Instance.ToggleMusic();
        }
        if (toggleSFX)
        {
            AudioManager.Instance.ToggleSFX();
        }
    }
}
