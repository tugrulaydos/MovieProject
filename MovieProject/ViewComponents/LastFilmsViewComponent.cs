using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace MovieProject.ViewComponents
{
	public class LastFilmsViewComponent:ViewComponent
	{
        FilmManager _filmManager = new FilmManager(new EFFilmDal());

        public IViewComponentResult Invoke()
		{
			var values = _filmManager.GetFilmCategoryArtistTake6();

			return View(values);

		}


	}
}
