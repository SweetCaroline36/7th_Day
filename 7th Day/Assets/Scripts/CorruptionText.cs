using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CorruptionText : MonoBehaviour
{
    public static int amount = 0;
    [SerializeField] private TextMeshProUGUI textBox;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        if (amount < 0) amount = 0;
        if (amount > 100) amount = 100;
        textBox.text = amount.ToString() + "/100";
    }
}