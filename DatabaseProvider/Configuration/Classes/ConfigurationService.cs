using DatabaseProvider.Configuration.Interfaces;
using Gateway.Services.Configuration.Classes;
using Newtonsoft.Json;

namespace Gateway.Services.Implementations
{
	public class ConfigurationService : IConfigurationService
	{
		private readonly string _configFilePath = "config.json";
		private IConfig _config;
		public ConfigurationService(IConfig config)
		{
			_config = config;
		}
		public IConfig GetAppSettings()
		{


			if (File.Exists(_configFilePath))
			{

				string json = File.ReadAllText(_configFilePath);
				_config = JsonConvert.DeserializeObject<Config>(json);
			}
			else
			{

				SaveAppSettings(_config);
			}

			return _config;
		}

		public void SaveAppSettings(IConfig appSettings)
		{
			string json = JsonConvert.SerializeObject(appSettings);
			File.WriteAllText(_configFilePath, json);
		}
	}
}
