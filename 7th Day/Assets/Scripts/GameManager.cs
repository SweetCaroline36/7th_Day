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

    [SerializeField] private GameObject tutorialCanvas, corruptionCanvas, buttonCanvas, gameOverCanvas;

    [SerializeField] private GameObject[] buttons;

    [SerializeField] private RectTransform expandTextBox;

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
    public void GameOver()
    {
        gameOver = true;
        //scoreCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        //DiceManager.Instance.stopDragger();
    }

    public void ChangeState(GameState newState)
    {
        GameState = newState;
        switch (newState)
        {
            case GameState.Tutorial:
                for(int i = 0; i < buttons.Length; i++)
                {
                    buttons[i].SetActive(false);
                }
                corruptionCanvas.SetActive(false);
                TextController.Instance.StartTutorial();
                break;
            case GameState.Game:
                tutorialCanvas.SetActive(false);
                break;
            case GameState.GameOver:
                GameOver();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }
    }

    public void activateCorruptionBar()
    {
        corruptionCanvas.SetActive(true);
    }
    public void activateTemptations()
    {
        for(int i = 0; i < 3; i++)
        {
            buttons[i].SetActive(true);
        }
    }
    public void activateBible()
    {
        buttons[4].SetActive(true);
        expandTextBox.offsetMax += new Vector2(-300, 0);
    }
    public void activateGary()
    {
        buttons[6].SetActive(true);
    }
    public void activateRest()
    {
        buttons[3].SetActive(true);
        buttons[5].SetActive(true);
    }
}

public enum GameState
{
    Tutorial = 0,
    Game = 1,
    GameOver = 2
}
