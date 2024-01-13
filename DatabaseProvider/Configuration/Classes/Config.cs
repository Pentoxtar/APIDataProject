using DatabaseProvider.Configuration.Interfaces;

namespace Gateway.Services.Configuration.Classes
{
	public class Config : IConfig
	{
		public string LogFilePath { get; set; }

		public string SqliteDbPath { get; set; }
	}
}
