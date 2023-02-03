using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class HumanController : MonoBehaviour
{
    [SerializeField] private AIPath ai;
    [SerializeField] private bool walkingTowardsTree = true;
    [SerializeField] private bool tempted = false;
    [SerializeField] private float speed = 1;
    private Vector3 treePos;
    private Vector3 startingPos;
    private Vector3 goalPos;
    private Coroutine activeCoroutine = null;
    //private Collider2D[] obstacleColliders;

    void Start()
    {
        GameObject tree = GameObject.FindWithTag("Tree");

        /*
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstacleColliders[i] = obstacles[i].GetComponent<Collider2D>();
        }
        */

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

    public void headToTree()
    {
        walkingTowardsTree = true;
        ai.destination = treePos;
        ai.SearchPath();
    }

    public void headToLocationAI(Vector3 location)
    {
        ai.destination = location;
        ai.SearchPath();
    }

    public void startTemptation(Vector3 target, float duration)
    {
        ai.isStopped = true;
        setGoalPos(target);
        tempted = true;
        StartCoroutine(distracted(duration));
    }

    public void setGoalPos(Vector3 target)
    {
        goalPos = target;
    }

    public void headTowardsLocation(Vector3 target)
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }

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

    public IEnumerator distracted(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        tempted = false;
        ai.isStopped = false;
        //goalPos = null;

        yield break;
    }

    public void togglePath()
    {
        ai.isStopped = !ai.isStopped;
    }
}
