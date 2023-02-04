using UnityEngine;

public class Highlight : MonoBehaviour
{
    void Start()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = this.gameObject.transform.parent.gameObject.GetComponent<SpriteRenderer>().sprite;
    }
}
