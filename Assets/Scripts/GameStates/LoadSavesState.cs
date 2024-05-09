public class LoadSavesState : IState
{
    private readonly GameSettings gameSettings;
    private readonly GameStateMachine gameStateMachine;
    private readonly SaveLoadService saveLoadService;


    public LoadSavesState(GameSettings gameSettings, GameStateMachine gameStateMachine, SaveLoadService saveLoadService)
    {
        this.gameSettings = gameSettings;
        this.gameStateMachine = gameStateMachine;
        this.saveLoadService = saveLoadService;
    }


    public void Enter()
    {
        LoadSavesOrCreateNew();
        gameStateMachine.Enter<LoadMenuState>();
    }
    
    
    private void LoadSavesOrCreateNew()
    {
        gameSettings.GameSettingsData = saveLoadService.Load() ?? CreateNew();
    }


    private GameSettingsData CreateNew()
    {
        GameSettingsData gameSettingsData = new GameSettingsData();
        gameSettingsData.availableCardPairs = 10;
        gameSettingsData.isSoundOn = true;

        return gameSettingsData;
    }
}