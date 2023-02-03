using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    [SerializeField] private float existenceDuration;
    private bool placed = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (placed)
        {
            if (existenceDuration <= 0)
            {
                //add animation coroutine here
                Destroy(this.gameObject);
            }

            existenceDuration -= Time.deltaTime;
        }
    }

    public void placeItem()
    {
        placed = true;
    }

    public float getExistenceDuration()
    {
        return existenceDuration;
    }
}
