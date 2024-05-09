using System.IO;


public class JsonSettingsSaver : ISettingsSaver
{
    private const string SAVE_NAME = "GameOptionsJsonSave";
    private const string DIRECTORY_NAME = "Saves";
    
    public void SaveSettings(GameSettings gameSettings)
    {
        if (!Directory.Exists(DIRECTORY_NAME))
        {
            Directory.CreateDirectory(DIRECTORY_NAME);
        }

        string saveJson = gameSettings.GameSettingsData.ToJson();

        string filePath = $"{DIRECTORY_NAME}/{SAVE_NAME}.json";
        
        File.WriteAllText(filePath, saveJson);
    }


    public GameSettingsData LoadSettings()
    {
        string filePath =$"{DIRECTORY_NAME}/{SAVE_NAME}.json";
        string json = File.ReadAllText(filePath);

        GameSettingsData gameSettingsData= json.ToDeserialize<GameSettingsData>();
        
        return gameSettingsData;
    }
}
