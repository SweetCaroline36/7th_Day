using UnityEngine;

public class RadiusBehavior : MonoBehaviour
{
    [SerializeField] private ItemBehavior itemBehavior;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Human")
        {
            if(this.gameObject.transform.parent.gameObject.tag == "Virtue")
            {
                other.gameObject.GetComponent<HumanController>().headAwayFromTree(itemBehavior.getEffectDuration());
            } else
            {
                other.gameObject.GetComponent<HumanController>().startTemptation(new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0), itemBehavior.getExistenceDuration());
            }
        }
    }
}
