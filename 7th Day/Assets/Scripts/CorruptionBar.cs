using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CorruptionBar : MonoBehaviour
{
    public static CorruptionBar Instance;
    [SerializeField] private Slider slider;

    void Start()
    {
        Instance = this;
    }

    public void SetValue(int amount)
    {
        slider.value = amount;
    }

    public int GetValue()
    {
        return (int) slider.value;
    }
}
