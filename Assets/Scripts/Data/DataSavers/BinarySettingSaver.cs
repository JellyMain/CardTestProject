using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class BinarySettingsSaver : ISettingsSaver
{
    private const string SAVE_NAME = "GameOptionsBinarySave";
    private const string DIRECTORY_NAME = "Saves";


    public void SaveSettings(GameSettings gameSettings)
    {
        if (!Directory.Exists(DIRECTORY_NAME))
        {
            Directory.CreateDirectory(DIRECTORY_NAME);
        }

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream createdFile = File.Create($"{DIRECTORY_NAME}/{SAVE_NAME}.bin");

        formatter.Serialize(createdFile, gameSettings.GameSettingsData);

        createdFile.Close();
    }


    public GameSettingsData LoadSettings()
    {
        if (!Directory.Exists(DIRECTORY_NAME)) return null;

        BinaryFormatter formatter = new BinaryFormatter();

        FileStream saveFile = File.Open($"{DIRECTORY_NAME}/{SAVE_NAME}.bin", FileMode.Open);

        GameSettingsData gameSettingsData = (GameSettingsData)formatter.Deserialize(saveFile);

        return gameSettingsData;
    }
}
