using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace MovieProject.Controllers
{
	public class HomePageController : Controller
	{

		FilmManager _filmManger = new FilmManager(new EFFilmDal()); 
		public IActionResult Index()		
		{
            var values = _filmManger.FilmCategory();
           
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
