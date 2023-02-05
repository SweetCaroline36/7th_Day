using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState GameState;

    [SerializeField] private GameObject tutorialCanvas, corruptionCanvas, buttonCanvas, gameOverCanvas, skipButton;

    [SerializeField] private GameObject[] buttons;

    [SerializeField] private RectTransform expandTextBox;

    [SerializeField] private AudioClip gameMusic, cutsceneMusic;

    [SerializeField] private bool gameOver = false;


    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        ChangeState(GameState.Tutorial);
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

    public bool getGameOver()
    {
        return gameOver;
    }
    public void GameOver(int ending)
    {
        gameOver = true;
        print("game ended: ending " + ending);
        //scoreCanvas.SetActive(false);
        //gameOverCanvas.SetActive(true);
        //DiceManager.Instance.stopDragger();
    }

    public void activateGameOverCanvas()
    {
        gameOverCanvas.SetActive(true);
    }

    public void ChangeState(GameState newState)
    {
        GameState = newState;
        switch (newState)
        {
            case GameState.Tutorial:
                CorruptionBar.Instance.SetValue(0);
                AudioManager.Instance.StopMusic();
                AudioManager.Instance.PlayMusic(cutsceneMusic);
                gameOver = false;
                activateAll(false);
                corruptionCanvas.SetActive(false);
                TextController.Instance.StartTutorial();
                break;
            case GameState.Game:
                gameOver = false;
                HumanManager.Instance.gameStart();
                AudioManager.Instance.StopDialogue();
                AudioManager.Instance.StopMusic();
                AudioManager.Instance.PlayMusic(gameMusic);
                activateAll(true);
                activateCorruptionBar(true);
                CorruptionBar.Instance.SetValue(0);
                enableSkipButton(false);
                tutorialCanvas.SetActive(false);
                break;
            case GameState.GoodEnding:
                activateCorruptionBar(false);
                activateAll(false);
                tutorialCanvas.SetActive(true);
                TextController.Instance.StartGoodEnding();
                GameOver(4);
                break;
            case GameState.TreeEnding:
                activateCorruptionBar(false);
                activateAll(false);
                tutorialCanvas.SetActive(true);
                TextController.Instance.StartTreeEnding();
                GameOver(1);
                break;
            case GameState.CorruptionEnding:
                activateAll(false);
                tutorialCanvas.SetActive(true);
                TextController.Instance.StartCorruptionEnding();
                GameOver(3);
                break;
            case GameState.KillAllEnding:
                activateCorruptionBar(false);
                activateAll(false);
                tutorialCanvas.SetActive(true);
                TextController.Instance.StartKillAllEnding();
                GameOver(2);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }

    public void activateCorruptionBar(bool on)
    {
        corruptionCanvas.SetActive(on);
    }
    public void activateTemptations()
    {
        for(int i = 0; i < 2; i++)
        {
            buttons[i].SetActive(true);
        }
    }
    public void activateBible()
    {
        buttons[4].SetActive(true);
        buttons[5].SetActive(true);
        expandTextBox.offsetMax += new Vector2(-300, 0);
    }
    public void activateGary()
    {
        buttons[6].SetActive(true);
    }
    public void activateRest()
    {
        buttons[3].SetActive(true);
        buttons[2].SetActive(true);
    }

    private void activateAll(bool on)
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].SetActive(on);
            buttons[i].GetComponent<Button>().interactable = true;
        }
    }
    private void enableSkipButton(bool enabled)
    {
        skipButton.SetActive(enabled);
    }

    public void skipTutorial()
    {
        ChangeState(GameState.Game);
    }
}

public enum GameState
{
    Tutorial = 0,
    Game = 1,
    GoodEnding = 2,
    TreeEnding = 3,
    CorruptionEnding = 4,
    KillAllEnding = 5
}
