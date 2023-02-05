using UnityEngine;

public class RadiusAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Animation anim;
    [SerializeField] private float speed;

    void Awake()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    void Start()
    {
        print(anim.clip.ToString());
        animator.speed = speed;
        animator.Play(anim.clip.ToString(), 0, 0);
    }
}
