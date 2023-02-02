using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject activeItemPrefab;
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

    public void holdItem()
    {
        holding = true;
        Vector3 mousePos = Input.mousePosition;
        var item = Instantiate(activeItemPrefab, Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, 10.0f)), Quaternion.identity);
        activeItem = item;
    }

    public void placeItem()
    {
        holding = false;
        activeItem.transform.GetChild(0).gameObject.GetComponent<CircleCollider2D>().enabled = true;
        activeItem = null;
    }
}
