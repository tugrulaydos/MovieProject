using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace MovieProject.ViewComponents
{
	public class LastFilmsViewComponent:ViewComponent
	{
		FilmManager filmManager = new FilmManager(new EFFilmDal());

		public IViewComponentResult Invoke()
		{
			var values = filmManager.TGetList();

			return View();

		}


	}
}
