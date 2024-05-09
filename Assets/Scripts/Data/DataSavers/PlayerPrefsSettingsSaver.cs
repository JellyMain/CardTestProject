using UnityEngine;


public class PlayerPrefsSettingsSaver : ISettingsSaver
{
    private const string CARD_PAIRS = "CardPairs";
    private const string IS_SOUND_ON = "IsSoundOn";
    
    public void SaveSettings(GameSettings gameSettings)
    {
        PlayerPrefs.SetInt(CARD_PAIRS, gameSettings.GameSettingsData.availableCardPairs);
        PlayerPrefs.SetInt(IS_SOUND_ON, gameSettings.GameSettingsData.isSoundOn ? 1 : 0);
        PlayerPrefs.Save();
    }

    
    
    
    public GameSettingsData LoadSettings()
    {
        GameSettingsData gameSettingsData = new GameSettingsData();
        
        gameSettingsData.availableCardPairs =PlayerPrefs.GetInt(CARD_PAIRS);
        gameSettingsData.isSoundOn =PlayerPrefs.GetInt(IS_SOUND_ON) == 1;

        return gameSettingsData;
    }
}
