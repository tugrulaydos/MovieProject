using Microsoft.AspNetCore.Mvc;

namespace MovieProject.Controllers
{
	public class MovieDetailController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
