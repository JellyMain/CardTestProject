using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;


public class SettingsUI : MonoBehaviour
{
    [SerializeField] private Toggle soundToggle;
    [SerializeField] private TMP_Text cardPairsText;
    [SerializeField] private int maxPairAmount = 10;
    [SerializeField] private int minPairAmount = 5;
    private MusicPlayer musicPlayer;
    private SaveLoadService saveLoadService;
    private GameSettings gameSettings;
    private int cardPairsAmount = 10;
    private bool isSoundOn = true;



    [Inject]
    private void Construct(SaveLoadService saveLoadService, GameSettings gameSettings, MusicPlayer musicPlayer)
    {
        this.saveLoadService = saveLoadService;
        this.gameSettings = gameSettings;
        this.musicPlayer = musicPlayer;
    }


    private void OnEnable()
    {
        LoadSavedData();
        soundToggle.onValueChanged.AddListener(ToggleListener);
    }


    private void OnDisable()
    {
        soundToggle.onValueChanged.RemoveListener(ToggleListener);
    }


    public void PlusPairsAmount()
    {
        if (cardPairsAmount < maxPairAmount)
        {
            cardPairsAmount++;
            UpdateSettingsUI();
        }
    }


    public void MinusPairsAmount()
    {
        if (cardPairsAmount > minPairAmount)
        {
            cardPairsAmount--;
            UpdateSettingsUI();
        }
    }


    public void SaveGameOptions()
    {
        gameSettings.GameSettingsData.availableCardPairs = cardPairsAmount;
        gameSettings.GameSettingsData.isSoundOn = isSoundOn;
        
        if (musicPlayer != null)
        {
            musicPlayer.ToggleMusic(isSoundOn);
        }
        else
        {
            Debug.Log("MusicPlayer is null");
        }
        
        saveLoadService.SaveSettings();
    }


    private void LoadSavedData()
    {
        cardPairsAmount = gameSettings.GameSettingsData.availableCardPairs;
        isSoundOn = gameSettings.GameSettingsData.isSoundOn;
        UpdateSettingsUI();
    }



    private void UpdateSettingsUI()
    {
        cardPairsText.text = cardPairsAmount.ToString();
        soundToggle.isOn = isSoundOn;
    }


    private void ToggleListener(bool value)
    {
        isSoundOn = value;
    }
}
