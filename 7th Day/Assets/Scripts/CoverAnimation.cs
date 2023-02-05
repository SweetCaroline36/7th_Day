//using System.Windows.Forms;
using UnityEngine;

public class CoverAnimation : MonoBehaviour
{
    [SerializeField] private float speed = 0.3f;
    private Animator animator;
    private GameObject parent;

    //[SerializeField] private GameObject button;
    void Awake()
    {
        animator = this.gameObject.GetComponent<Animator>();
        parent = this.gameObject.transform.parent.gameObject;
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.98)
        {
            //button.GetComponent<Button>().enabled = true;
            parent.SetActive(false);
        }
    }

    public void startAnimation()
    {
        //button.GetComponent<Button>().enabled = false;
        animator.speed = speed;
        animator.Play("CooldownCover", 0, 0);
    }

    public Animator GetAnimator() 
    {
        return animator;
    }
}
