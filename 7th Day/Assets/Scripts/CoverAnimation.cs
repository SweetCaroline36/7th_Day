//using System.Windows.Forms;
using UnityEngine;
using UnityEngine.UI;

public class CoverAnimation : MonoBehaviour
{
    [SerializeField] private float speed = 0.3f;
    private Animator animator;
    private GameObject parent; 
    private Button button;

    void Awake()
    {
        animator = this.gameObject.GetComponent<Animator>();
        parent = this.gameObject.transform.parent.gameObject;
        button = this.gameObject.transform.parent.gameObject.transform.parent.gameObject.GetComponent<Button>();
    }

    void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.98)
        {
            //button.GetComponent<Button>().enabled = true;
            button.interactable = true;
            parent.SetActive(false);
        }
    }

    public void startAnimation()
    {
        //button.GetComponent<Button>().enabled = false;
        button.interactable = false;
        animator.speed = speed;
        animator.Play("CooldownCover", 0, 0);
    }

    public Animator GetAnimator() 
    {
        return animator;
    }
}
