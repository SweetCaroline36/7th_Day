using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanManager : MonoBehaviour
{
    public static HumanManager Instance;

    [SerializeField] private GameObject humanPrefab;
    [SerializeField] private Sprite[] spriteOptions;
    private GameObject[] spawnZones;
    private List<GameObject> humans;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        spawnZones = GameObject.FindGameObjectsWithTag("SpawnZone");
    }

    public void spawnHuman()
    {
        CorruptionText.amount -= 30;
        CorruptionBar.Instance.SetValue(CorruptionText.amount);
        GameObject newHuman = Instantiate(humanPrefab, randomLocation(), Quaternion.identity);
        humans.Add(newHuman);
        newHuman.GetComponent<SpriteRenderer>().sprite = spriteOptions[randomIndex()];
        newHuman.GetComponent<HumanController>().setSpeed(Random.Range(1f, 2f));
    }

    private int randomIndex()
    {
        return Random.Range(0, spriteOptions.Length);
    }

    public Vector3 randomLocation()
    {
        GameObject randomZone = spawnZones[Random.Range(0, spawnZones.Length)];
        return new Vector3(randomZone.transform.position.x, randomZone.transform.position.y, 0);
    }
}
