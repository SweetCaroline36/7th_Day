using UnityEngine;

public class HumanController : MonoBehaviour
{
    [SerializeField] private float speed;
    //private Collider2D playerCollider;

    void Start()
    {
        //playerCollider = GetComponent<Collider2D>();
    }

    void Update()
    {
        //if (playerCollider.IsTouching(colliders[i]))
        //{
        //pots[i].GetComponent<Falling>().startFalling();
        //}
        transform.position += Vector3.up * speed * Time.deltaTime;
    }

    
}
