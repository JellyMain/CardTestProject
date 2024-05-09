using UnityEngine;
using Zenject;


public class GameMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject settingsScreen;
    private GameStateMachine gameStateMachine;


    [Inject]
    private void Construct(GameStateMachine gameStateMachine)
    {
        this.gameStateMachine = gameStateMachine;
    }
    


    public void StartGame()
    {
        gameStateMachine.Enter<LoadLevelState>();
    }


    public void OpenSettings()
    {
        settingsScreen.SetActive(true);
    }


    public void ReturnBack()
    {
        settingsScreen.SetActive(false);
    }
}
