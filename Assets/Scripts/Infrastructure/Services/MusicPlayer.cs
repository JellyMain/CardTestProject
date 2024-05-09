using System;
using UnityEngine;
using Zenject;


public class MusicPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    private GameSettings gameSettings;

    public static MusicPlayer Instance { get; private set; }


    [Inject]
    private void Construct(GameSettings gameSettings)
    {
        this.gameSettings = gameSettings;
    }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(Instance.gameObject);
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }


    private void Start()
    {
        ToggleMusic(gameSettings.GameSettingsData.isSoundOn);
    }


    public void ToggleMusic(bool value)
    {
        audioSource.mute = !value;
    }
}
