
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanManager : MonoBehaviour
{
    public static HumanManager Instance;

    [SerializeField] private GameObject humanPrefab;
    [SerializeField] private Sprite[] spriteOptions;
    private GameObject[] spawnZones;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        spawnZones = GameObject.FindGameObjectsWithTag("SpawnZone");
    }

    public void gameStart()
    {
        var humans = GameObject.FindGameObjectsWithTag("Human");
        for (int i = 0; i < humans.Length; i++)
        {
            Destroy(humans[i]);
        }
        GameObject adam = Instantiate(humanPrefab, new Vector3(1f, -17f, 0), Quaternion.identity);
        adam.GetComponent<SpriteRenderer>().sprite = spriteOptions[0];
        GameObject eve = Instantiate(humanPrefab, new Vector3(-29.5f, 32f, 0), Quaternion.identity);
        eve.GetComponent<SpriteRenderer>().sprite = spriteOptions[1];
    }

    public void spawnHuman()
    {
        CorruptionText.amount -= 40;
        CorruptionBar.Instance.SetValue(CorruptionText.amount);
        GameObject newHuman = Instantiate(humanPrefab, randomLocation(), Quaternion.identity);
        newHuman.GetComponent<SpriteRenderer>().sprite = spriteOptions[randomIndex()];
        newHuman.GetComponent<HumanController>().setSpeed(Random.Range(1f, 2f));
    }

    private int randomIndex()
    {
        int randIndex = Random.Range(0, spriteOptions.Length);
        print(randIndex);
        return randIndex;
    }

    public Vector3 randomLocation()
    {
        GameObject randomZone = spawnZones[Random.Range(0, spawnZones.Length)];
        return new Vector3(randomZone.transform.position.x, randomZone.transform.position.y, 0);
    }
}
