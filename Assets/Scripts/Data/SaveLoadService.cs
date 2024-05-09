using System;
using System.Collections.Generic;


public class SaveLoadService
{
    private readonly GameSettings gameSettings;

    private readonly Dictionary<Type, ISettingsSaver> settingsSavers;


    public SaveLoadService(GameSettings gameSettings)
    {
        this.gameSettings = gameSettings;
        
        settingsSavers = new Dictionary<Type, ISettingsSaver>()
        {
            [typeof(BinarySettingsSaver)] = new BinarySettingsSaver(),
            [typeof(JsonSettingsSaver)] = new JsonSettingsSaver(),
            [typeof(PlayerPrefsSettingsSaver)] = new PlayerPrefsSettingsSaver()
        };
    }


    public GameSettingsData Load()
    {
        return settingsSavers[typeof(BinarySettingsSaver)].LoadSettings();
    }


    public void SaveSettings()
    {
        foreach (KeyValuePair<Type, ISettingsSaver> saver in settingsSavers)
        {
            saver.Value.SaveSettings(gameSettings);
        }
    }
}
