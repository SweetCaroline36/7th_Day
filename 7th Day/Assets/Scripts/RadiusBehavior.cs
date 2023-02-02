using UnityEngine;

public class RadiusBehavior : MonoBehaviour
{
    [SerializeField] private float duration;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Human")
        {
            if(this.gameObject.transform.parent.gameObject.tag == "Virtue")
            {
                other.gameObject.GetComponent<HumanController>().headAwayFromTree(duration);
            } else
            {
                other.gameObject.GetComponent<HumanController>().headToLocation(new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0));
            }
        }
    }
}
