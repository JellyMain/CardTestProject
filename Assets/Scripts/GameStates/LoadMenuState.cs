using System;


public class LoadMenuState : IState
{
    private readonly SceneLoader sceneLoader;
    private const string MAIN_MENU = "MenuScene";


    public LoadMenuState(SceneLoader sceneLoader)
    {
        this.sceneLoader = sceneLoader;
    }


    public void Enter()
    {
        sceneLoader.Load(MAIN_MENU);
    }
}
