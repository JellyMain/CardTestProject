public interface ISettingsSaver
{
    public void SaveSettings(GameSettings gameSettings);
    public GameSettingsData LoadSettings();
}

