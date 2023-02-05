using UnityEngine;

public class TextController : MonoBehaviour
{
    public static TextController Instance;
    public StoryScene currentScene;
    public BottomBarController bottomBar;

    void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (bottomBar.IsCompleted())
            {
                if (bottomBar.getIndex() == 9)
                {
                    GameManager.Instance.activateCorruptionBar(true);
                }
                if (bottomBar.getIndex() == 7)
                {
                    GameManager.Instance.activateTemptations();
                }
                if (bottomBar.getIndex() == 10)
                {
                    GameManager.Instance.activateBible();
                }
                if (bottomBar.getIndex() == 12)
                {
                    GameManager.Instance.activateGary();
                }
                if (bottomBar.IsLastSentence())
                {
                    GameManager.Instance.ChangeState(GameState.Game);

                    //currentScene = currentScene.nextScene;
                    //bottomBar.PlayScene(currentScene);
                } else
                {
                    bottomBar.PlayNextSentence();
                }
            }
        }
    }

    public void StartTutorial()
    {
        bottomBar.PlayScene(currentScene);
    }
}
