using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject biblePrefab, boozePrefab, tammiPrefab, moneyPrefab, knifePrefab;
    [SerializeField] private float angelSpeedIncrease = 2f;
    [SerializeField] private float offset;

    private bool holding = false;
    public static bool murdering = false;

    private GameObject activeItem;

    void Start()
    {

    }

    void Update()
    {
        if(holding && !murdering)
        {
            Vector3 mousePos = Input.mousePosition;
            activeItem.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10.0f));
            if (Input.GetMouseButtonDown(0) && !murdering)
            {
                placeItem();
            }
        } else if (holding && murdering) {
            Vector3 mousePos = Input.mousePosition;
            activeItem.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x + offset + 10f, mousePos.y - offset, 10.0f));
        }
    }

    public void createBible()
    {
        CorruptionText.amount -= biblePrefab.GetComponent<ItemBehavior>().getCost();
        CorruptionBar.Instance.SetValue(CorruptionText.amount);
        holdItem(biblePrefab);
    }
    public void createBooze()
    {
        CorruptionText.amount += boozePrefab.GetComponent<ItemBehavior>().getCost();
        CorruptionBar.Instance.SetValue(CorruptionText.amount);
        holdItem(boozePrefab);
    }
    public void createMoney()
    {
        CorruptionText.amount += moneyPrefab.GetComponent<ItemBehavior>().getCost();
        CorruptionBar.Instance.SetValue(CorruptionText.amount);
        holdItem(moneyPrefab);
    }
    public void createTammi()
    {
        CorruptionText.amount += tammiPrefab.GetComponent<ItemBehavior>().getCost();
        CorruptionBar.Instance.SetValue(CorruptionText.amount);
        holdItem(tammiPrefab);
    }
    public void createKnife()
    {
        CorruptionText.amount += knifePrefab.GetComponent<ItemBehavior>().getCost();
        CorruptionBar.Instance.SetValue(CorruptionText.amount);
        if(!GameManager.Instance.getGameOver())
        {
            murdering = true;
            holdItem(knifePrefab);
        }
    }
    public void createAngel()
    {
        CorruptionText.amount = 0;
        CorruptionBar.Instance.SetValue(CorruptionText.amount);
        increaseSpeed();
    }

    //angel effect
    private void increaseSpeed()
    {
        var humans = GameObject.FindGameObjectsWithTag("Human");
        for(int i = 0; i < humans.Length; i++)
        {
            var controller = humans[i].GetComponent<HumanController>();
            var currentSpeed = controller.getSpeed();
            controller.setSpeed(currentSpeed *= angelSpeedIncrease);
        }
    }

    public void holdItem(GameObject i)
    {
        holding = true;
        Vector3 mousePos = Input.mousePosition;
        var item = Instantiate(i, Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10.0f)), Quaternion.identity);
        activeItem = item;
    }

    public void placeItem()
    {
        holding = false;
        //AnimationManager.Instance.startAnimation();
        activeItem.GetComponent<ItemBehavior>().placeItem();
        activeItem.transform.GetChild(0).gameObject.GetComponent<CircleCollider2D>().enabled = true;
        activeItem = null;
    }

    public void stopHoldingKnife()
    {
        holding = false;
        //Destroy(activeItem);
        activeItem = null;
    }
}
