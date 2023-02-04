using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    [SerializeField] private float existenceDuration;
    [SerializeField] private float effectDuration;
    [SerializeField] private float cooldownMax;
    [SerializeField] private int cost;
    private bool placed = false;
    private bool canBeSelected = true;
    private float cooldown = 0;

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

        if(!canBeSelected)
        {

        }
    }

    public void placeItem()
    {
        placed = true;
        canBeSelected = false;
        cooldown = cooldownMax;
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
