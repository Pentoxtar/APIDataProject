using SqliteProvider.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqliteProvider.Repositories
{
	public interface IOrganizatonRepository
	{
		void AddOrganization(Organization organization);

		List<Organization> GetAllOrganizations();
	}
}
