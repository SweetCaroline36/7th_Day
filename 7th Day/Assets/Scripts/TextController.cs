using UnityEngine;

public class TextController : MonoBehaviour
{
    public static TextController Instance;

    [SerializeField] private StoryScene[] scenes;
    //public StoryScene currentScene;
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
                if (bottomBar.IsLastSentence() && !GameManager.Instance.getGameOver())
                {
                    GameManager.Instance.ChangeState(GameState.Game);

                    //currentScene = currentScene.nextScene;
                    //bottomBar.PlayScene(currentScene);
                } else if (bottomBar.IsLastSentence() && GameManager.Instance.getGameOver())
                {
                    GameManager.Instance.activateGameOverCanvas();
                }
                else
                {
                    bottomBar.PlayNextSentence();
                }
            }
        }
    }

    public void StartTutorial()
    {
        bottomBar.PlayScene(scenes[0]);
    }
    public void StartGoodEnding()
    {
        bottomBar.PlayScene(scenes[1]);
    }
    public void StartTreeEnding()
    {
        bottomBar.PlayScene(scenes[2]);
    }
    public void StartCorruptionEnding()
    {
        bottomBar.PlayScene(scenes[3]);
    }
    public void StartKillAllEnding()
    {
        bottomBar.PlayScene(scenes[4]);
    }
}
