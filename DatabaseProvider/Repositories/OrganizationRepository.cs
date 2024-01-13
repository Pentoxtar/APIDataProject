using DatabaseProvider.Configuration.Interfaces;
using Microsoft.Data.Sqlite;
using SqliteProvider.Models;
namespace SqliteProvider.Repositories
{
	public class OrganizationRepository : IOrganizatonRepository
	{
		private readonly IConfigurationService _configService;
		private readonly IConfig config;

		public OrganizationRepository(IConfigurationService configurationService)
		{
			_configService = configurationService;
			config = _configService.GetAppSettings();
		}

		public void AddOrganization(Organization organization)
		{
			using (SqliteConnection connection = new SqliteConnection($"Data Source = {config.SqliteDbPath}"))
			{
				connection.Open();
				SqliteCommand command = connection.CreateCommand();
				string query = "INSERT INTO Organizations (Index, Organization_Id, Name, Website, Country, Description, Founded, Industry, Number_Of_Employees) " +
							   "VALUES (@index, @organizationId, @name, @website, @country, @description, @founded, @industry, @numberOfEmployees)";
				command.CommandText = query;
				command.Parameters.AddWithValue("@index", organization.Index);
				command.Parameters.AddWithValue("@organizationId", organization.Organization_Id);
				command.Parameters.AddWithValue("@name", organization.Name);
				command.Parameters.AddWithValue("@website", organization.Website);
				command.Parameters.AddWithValue("@country", organization.Country);
				command.Parameters.AddWithValue("@description", organization.Description);
				command.Parameters.AddWithValue("@founded", organization.Founded);
				command.Parameters.AddWithValue("@industry", organization.Industry);
				command.Parameters.AddWithValue("@numberOfEmployees", organization.Number_Of_Emplooyes);

				command.ExecuteNonQuery();
			}
		}

		public List<Organization> GetAllOrganizations()
		{
			List<Organization> organizations = new List<Organization>();
			using (SqliteConnection connection = new SqliteConnection($"Data Source = {config.SqliteDbPath}"))
			{
				connection.Open();

				SqliteCommand command = connection.CreateCommand();
				string query = "SELECT * FROM Organizations";
				command.CommandText = query;
				using (SqliteDataReader reader = command.ExecuteReader())
				{
					while (reader.Read())
					{
						Organization organization = new Organization()
						{
							Index = reader.GetString(0),
							Organization_Id = reader.GetString(1),
							Name = reader.GetString(2),
							Website = reader.GetString(3),
							Country = reader.GetString(4),
							Description = reader.GetString(5),
							Founded = reader.GetString(6),
							Industry = reader.GetString(7),
							Number_Of_Emplooyes = Convert.ToInt32(reader.GetString(8))
						};
						organizations.Add(organization);
					}
				}
			}
			return organizations;
		}
	}
}
