using System;
using UnityEngine;
using Zenject;


public class GameSceneUIHandler : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject loseScreen;
    private const string MAIN_MENU = "MenuScene";
    private GameStateMachine gameStateMachine;

    
    [Inject]
    private void Construct(GameStateMachine gameStateMachine)
    {
        this.gameStateMachine = gameStateMachine;
    }


    private void OnEnable()
    {
        CardPairChecker.WonGame += ShowWinScreen;
        GameTimerUI.TimerIsUp += ShowLoseScreen;
    }


    private void OnDestroy()
    {
        CardPairChecker.WonGame -= ShowWinScreen;
        GameTimerUI.TimerIsUp -= ShowLoseScreen;
    }


    private void ShowWinScreen()
    {
        winScreen.SetActive(true);
    }


    private void ShowLoseScreen()
    {
        loseScreen.SetActive(true);
    }


    public void BackToMenu()
    {
        gameStateMachine.Enter<LoadMenuState>();
    }
}