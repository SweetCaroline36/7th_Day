using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CostText : MonoBehaviour
{
    private int cost = 0;
    // Start is called before the first frame update


    // Update is called once per frame
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = cost.ToString();
    }

    public void setCost(int newCost)
    {
        cost = newCost; 
    }
}