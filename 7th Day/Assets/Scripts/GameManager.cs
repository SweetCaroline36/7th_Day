using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            Reset();
        }
        if (Input.GetKeyDown("escape"))
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
            Application.Quit();
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }
}
