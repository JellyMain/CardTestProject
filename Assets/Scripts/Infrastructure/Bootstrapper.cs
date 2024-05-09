using UnityEngine;
using Zenject;


public class Bootstrapper : MonoInstaller, ICoroutineRunner, IInitializable
{
    [SerializeField] private LoadingScreen loadingScreenPrefab;


    public override void InstallBindings()
    {
        BindSaveLoadService();
        BindGameSettings();
        BindCardPairChecker();
        BindInstallerInterfaces();
        BindLoadingScreen();
        BindSceneLoader();
        BindGameStateMachine();
        BindAssetProvider();
        BindGameFactory();
        BindDeckCreator();
    }
    
    
    private void BindSaveLoadService()
    {
        Container.Bind<SaveLoadService>().AsSingle();
    }


    private void BindGameSettings()
    {
        Container.Bind<GameSettings>().AsSingle();
    }


    private void BindCardPairChecker()
    {
        Container.Bind<CardPairChecker>().AsSingle();
    }


    private void BindInstallerInterfaces()
    {
        Container.BindInterfacesTo<Bootstrapper>().FromInstance(this).AsSingle();
    }


    private void BindDeckCreator()
    {
        Container.Bind<DeckCreator>().AsSingle();
    }


    private void BindGameFactory()
    {
        Container.Bind<GameFactory>().AsSingle();
    }


    private void BindLoadingScreen()
    {
        Container.Bind<LoadingScreen>().FromComponentInNewPrefab(loadingScreenPrefab).AsSingle().NonLazy();
    }


    private void BindAssetProvider()
    {
        Container.Bind<AssetProvider>().AsSingle();
    }


    private void BindGameStateMachine()
    {
        Container.Bind<GameStateMachine>().AsSingle().NonLazy();
    }


    private void BindSceneLoader()
    {
        Container.Bind<SceneLoader>().AsSingle().NonLazy();
    }


    public void Initialize()
    {
        Container.Resolve<GameStateMachine>().Enter<LoadSavesState>();
    }
}