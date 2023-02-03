using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanSpawner : MonoBehaviour
{
    [SerializeField] private GameObject humanPrefab;
    [SerializeField] private Sprite[] spriteOptions;
    private GameObject[] spawnZones;

    void Start()
    {
        spawnZones = GameObject.FindGameObjectsWithTag("SpawnZone");
    }

    public void spawnHuman()
    {
        CorruptionText.amount -= 30;
        CorruptionBar.Instance.SetValue(CorruptionText.amount);
        GameObject newHuman = Instantiate(humanPrefab, randomLocation(), Quaternion.identity);
        newHuman.GetComponent<SpriteRenderer>().sprite = spriteOptions[randomIndex()];
    }

    private int randomIndex()
    {
        return Random.Range(0, spriteOptions.Length);
    }

    private Vector3 randomLocation()
    {
        GameObject randomZone = spawnZones[Random.Range(0, spawnZones.Length)];
        return new Vector3(randomZone.transform.position.x, randomZone.transform.position.y, 0);
    }
}
