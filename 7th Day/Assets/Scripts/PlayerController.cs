using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject biblePrefab, boozePrefab, tammiPrefab, moneyPrefab, knifePrefab;
    //[SerializeField] private CorruptionBar bar;
    private bool holding = false;
    private GameObject activeItem;

    void Start()
    {

    }

    void Update()
    {
        if(holding)
        {
            Vector3 mousePos = Input.mousePosition;
            activeItem.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10.0f));
            if (Input.GetMouseButtonDown(0))
            {
                placeItem();
            }
        }
    }

    public void createBible()
    {
        CorruptionText.amount -= 5;
        CorruptionBar.Instance.SetValue(CorruptionText.amount);
        holdItem(biblePrefab);
    }
    public void createBooze()
    {
        CorruptionText.amount += 4;
        CorruptionBar.Instance.SetValue(CorruptionText.amount);
        holdItem(boozePrefab);
    }
    public void createMoney()
    {
        CorruptionText.amount += 7;
        CorruptionBar.Instance.SetValue(CorruptionText.amount);
        holdItem(moneyPrefab);
    }
    public void createTammi()
    {
        CorruptionText.amount += 10;
        CorruptionBar.Instance.SetValue(CorruptionText.amount);
        holdItem(tammiPrefab);
    }
    public void createKnife()
    {
        CorruptionText.amount += 50;
        CorruptionBar.Instance.SetValue(CorruptionText.amount);
        holdItem(knifePrefab);
    }
    
    public void createAngel()
    {
        CorruptionText.amount = 0;
        CorruptionBar.Instance.SetValue(CorruptionText.amount);
        //holdItem(knifePrefab);
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
        activeItem.GetComponent<ItemBehavior>().placeItem();
        activeItem.transform.GetChild(0).gameObject.GetComponent<CircleCollider2D>().enabled = true;
        activeItem = null;
    }
}
