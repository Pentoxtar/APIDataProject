namespace DatabaseProvider.Configuration.Interfaces
{
    public interface IConfigurationService
    {
        public IConfig GetAppSettings();

        public void SaveAppSettings(IConfig appSettings);
    }
}
