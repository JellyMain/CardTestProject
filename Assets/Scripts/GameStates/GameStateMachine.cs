using System;
using System.Collections.Generic;


public class GameStateMachine
{
    private readonly Dictionary<Type, IState> states;


    public GameStateMachine(SceneLoader sceneLoader, GameFactory gameFactory, GameSettings gameSettings, SaveLoadService saveLoadService)
    {
        states = new Dictionary<Type, IState>()
        {
            [typeof(LoadSavesState)] = new LoadSavesState(gameSettings, this, saveLoadService),
            [typeof(LoadMenuState)] = new LoadMenuState(sceneLoader),
            [typeof(LoadLevelState)] = new LoadLevelState(sceneLoader, gameFactory, this),
            [typeof(GameLoopState)] = new GameLoopState()
        };
    }


    public void Enter<TState>() where TState : class, IState
    {
        TState newState = GetState<TState>();
        newState.Enter();
    }


    private TState GetState<TState>() where TState : class, IState
    {
        return states[typeof(TState)] as TState;
    }
}
