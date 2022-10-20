using Microsoft.AspNetCore.Mvc;

namespace MovieProject.Controllers
{
	public class HomePageController : Controller
	{
		public IActionResult Index()
		{

			return View();
		}
	}
}
