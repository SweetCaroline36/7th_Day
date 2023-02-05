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
                if (bottomBar.getIndex() == 1)
                {
                    GameManager.Instance.activateCorruptionBar();
                }
                if (bottomBar.getIndex() == 2)
                {
                    GameManager.Instance.activateTemptations();
                }
                if (bottomBar.getIndex() == 3)
                {
                    GameManager.Instance.activateBible();
                }
                if (bottomBar.getIndex() == 4)
                {
                    GameManager.Instance.activateGary();
                }
                if (bottomBar.getIndex() == 5)
                {
                    GameManager.Instance.activateRest();
                }
                if (bottomBar.IsLastSentence())
                {
                    print("end of text");
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
