using APIDataProject.Model;
using CsvHelper;
using DatabaseProvider.Configuration.Interfaces;
using System.Data.SQLite;
using System.Globalization;

namespace SqliteProvider.Repositories
{
	public class CsvService
	{
		private readonly IConfigurationService _configService;
		private readonly IConfig config;
		string inputFile = @"D:\organizations-100.csv";

		public CsvService(IConfigurationService configurationService)
		{
			_configService = configurationService;
			config = _configService.GetAppSettings();
		}

		public List<Organization> ReadCsv()
		{
			List<Organization> outputRecords = new List<Organization>();

			using var reader = new StreamReader(inputFile);
			using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
			var records = csv.GetRecords<Organization>();

			foreach (var record in records)
			{
				outputRecords.Add(record);
			}

			return outputRecords;
		}

		public void SaveToDatabase(List<Organization> records)
		{
			using (SQLiteConnection connection = new SQLiteConnection($"Data Source = {config.SqliteDbPath}"))
			{
				connection.Open();

				using var cmd = new SQLiteCommand(connection);

				foreach (var record in records)
				{
					cmd.CommandText = $"INSERT INTO Organizations(Index, Organization_Id, Name, Website, Country, Description, Founded, Industry, Number_Of_Employees) VALUES('{record.Index}', '{record.Organization_Id}', '{record.Name}', '{record.Website}', '{record.Country}', '{record.Description}', '{record.Founded}', '{record.Industry}', {record.Number_Of_Emplooyes})";
					cmd.ExecuteNonQuery();
				}
			}
		}

		public void ProcessCsv()
		{
			var records = ReadCsv();
			SaveToDatabase(records);
		}
	}
}
