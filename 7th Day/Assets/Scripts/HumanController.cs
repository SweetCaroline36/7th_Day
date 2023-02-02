using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class HumanController : MonoBehaviour
{
    [SerializeField] private AIPath ai;
    [SerializeField] private bool walkingTowardsTree = true;
    private Vector3 treePos;
    private Vector3 startingPos;

    void Start()
    {
        GameObject tree = GameObject.FindWithTag("Tree");
        startingPos = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, 0);
        treePos = new Vector3(tree.transform.position.x, tree.transform.position.y, 0);
        headToTree();
    }

    void Update()
    {
        
    }

    public void headToTree()
    {
        walkingTowardsTree = true;
        ai.destination = treePos;
        ai.SearchPath();
    }

    public void headToLocation(Vector3 location)
    {
        ai.destination = location;
        ai.SearchPath();
    }

    public void headAwayFromTree(float timer)
    {
        walkingTowardsTree = false;
        ai.destination = startingPos;
        ai.SearchPath();

        StartCoroutine(charmed(timer));
    }

    public IEnumerator charmed(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        ai.destination = treePos;
        ai.SearchPath();
        yield break;
    }

    public void togglePath()
    {
        ai.isStopped = !ai.isStopped;
    }
}
