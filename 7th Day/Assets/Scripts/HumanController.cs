using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class HumanController : MonoBehaviour
{
    [SerializeField] private AIPath ai;
    [SerializeField] private bool walkingTowardsTree = true;
    [SerializeField] private bool tempted = false;
    [SerializeField] private float speed;
    [SerializeField] private SpriteRenderer highlight;
    private Vector3 treePos;
    private Vector3 startingPos;
    private Vector3 goalPos;
    private Coroutine activeCoroutine = null;

    void Start()
    {
        GameObject tree = GameObject.FindWithTag("Tree");

        startingPos = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0);
        treePos = new Vector3(tree.transform.position.x, tree.transform.position.y, 0);
        headToTree();
    }

    void Update()
    {
        if(tempted)
        {
            headTowardsLocation(goalPos);
        }
    }

    //default
    public void headToTree()
    {
        walkingTowardsTree = true;
        ai.destination = treePos;
        ai.SearchPath();
    }

    //the three temptation items
    public void startTemptation(Vector3 target, float duration)
    {
        ai.isStopped = true;
        goalPos = target;
        tempted = true;
        StartCoroutine(distracted(duration));
    }

    public IEnumerator distracted(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        tempted = false;
        ai.isStopped = false;

        yield break;
    }

    public void headTowardsLocation(Vector3 target)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }

    //bible effects
    public void headAwayFromTree(float timer)
    {
        if (walkingTowardsTree)
        {
            walkingTowardsTree = false;
            ai.destination = startingPos;
            ai.SearchPath();

            activeCoroutine = StartCoroutine(charmed(timer));
        } else
        {
            StopCoroutine(activeCoroutine);
            activeCoroutine = StartCoroutine(charmed(timer));
        }
    }

    public IEnumerator charmed(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        ai.destination = treePos;
        ai.SearchPath();
        walkingTowardsTree = true;
        yield break;
    }

    //knife effects
    public void die()
    {
        Destroy(this.gameObject);
    }

    void OnMouseEnter()
    {
        if (PlayerController.murdering)
        {
            highlight.enabled = true;
        }
    }
    void OnMouseExit()
    {
        highlight.enabled = false;
    }
    void OnMouseDown()
    {
        if (PlayerController.murdering)
        {
            die();
            PlayerController.murdering = false;
        }
    }

    //angel effects (and spawner)
    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
        ai.maxSpeed = speed;
    }

    public float getSpeed()
    {
        return speed;
    }
}
