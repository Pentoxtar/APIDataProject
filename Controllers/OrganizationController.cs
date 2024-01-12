using APIDataProject.Model;
using Microsoft.AspNetCore.Mvc;

namespace APIDataProject.Controllers
{
	public class OrganizationController : Controller
	{
		
		public IActionResult Index()
		{
			return View();
		}
	}
}
