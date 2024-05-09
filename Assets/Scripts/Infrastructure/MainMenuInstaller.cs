using UnityEngine;
using Zenject;


public class MainMenuInstaller : MonoInstaller
{
    [SerializeField] private MusicPlayer musicPlayerPrefab;


    public override void InstallBindings()
    {
        BindMusicPlayer();
    }


    private void BindMusicPlayer()
    {
        Container.Bind<MusicPlayer>().FromComponentInNewPrefab(musicPlayerPrefab).AsSingle().NonLazy();
    }
}
