using UnityEngine;

public class TreeHitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Human")
        {
            GameManager.Instance.ChangeState(GameState.TreeEnding);
        }
    }
}
