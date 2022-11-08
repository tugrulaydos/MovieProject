using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace MovieProject.Controllers
{
	public class HomePageController : Controller
	{

		IFilmService _filmManager;

		public HomePageController(IFilmService filmManger)
		{
			_filmManager = filmManger;
		}

		public IActionResult Index()		
		{
			var values = _filmManager.GetFilmCategoryArtistTake6();
           
            return View(values);
            
		}

		public  PartialViewResult HomePagePartial()
		{		
			return PartialView();
		}

		public PartialViewResult HomePagePartial2()
		{

			return PartialView();
		}




	}
}
