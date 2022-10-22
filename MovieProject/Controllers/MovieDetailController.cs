using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace MovieProject.Controllers
{
	public class MovieDetailController : Controller
	{
		FilmManager _FilmManager = new FilmManager(new EFFilmDal());

		public IActionResult Index(int id)
		{            

			ViewBag.Value = _FilmManager.GetFilCtegoryByID(id);             

            return View();
		}

        public PartialViewResult DetailTop()
        {
          

            return PartialView();
        }
    }
}
