public class LoadLevelState : IState
{
    private readonly SceneLoader sceneLoader;
    private readonly GameFactory gameFactory;
    private readonly GameStateMachine gameStateMachine;
    private const string GAME_SCENE = "GameScene";


    public LoadLevelState(SceneLoader sceneLoader, GameFactory gameFactory, GameStateMachine gameStateMachine)
    {
        this.sceneLoader = sceneLoader;
        this.gameFactory = gameFactory;
        this.gameStateMachine = gameStateMachine;
    }


    public void Enter()
    {
        sceneLoader.Load(GAME_SCENE, CreateLevelObjects);
        gameStateMachine.Enter<GameLoopState>();
    }
    

    private void CreateLevelObjects()
    {
        gameFactory.CreateCardsContainer();
        gameFactory.CreateCards();
    }
}