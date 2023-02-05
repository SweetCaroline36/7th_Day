using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public static AnimationManager Instance;

    void Awake()
    {
        Instance = this;
    }

    public void startAnimation(CoverAnimation cover)
    {
        var anim = cover.GetAnimator();

        anim.Play("CooldownCover", 0, 0);
    }
}
