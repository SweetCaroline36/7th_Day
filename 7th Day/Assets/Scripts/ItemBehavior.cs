using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    [SerializeField] private float existenceDuration;
    [SerializeField] private float effectDuration;
    [SerializeField] private int cost;
    private bool placed = false;
    //private bool canBeSelected = true;

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
        //canBeSelected = false;
    }

    public float getExistenceDuration()
    {
        return existenceDuration;
    }
    public float getEffectDuration()
    {
        return effectDuration;
    }
    public int getCost()
    {
        return cost;
    }
}
