using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MovieProject.Controllers
{
	public class ArtistAdminController : Controller
	{
		ArtistManager _artistManager = new ArtistManager(new EFArtistDal());

		
		public IActionResult Index()
		{
			var values = _artistManager.TGetList();

			return View(values);
		}

		[HttpGet]
		public IActionResult UpdateArtist(int id)
		{
			Artist A1 = _artistManager.GetByID(id);
						

			return View(A1);
		}

		[HttpPost]
		public IActionResult UpdateArtist(Artist A)
		{		
			
			_artistManager.TUpdate(A);

			return RedirectToAction("Index", "ArtistAdmin");

		}


		[HttpGet]
		public IActionResult AddArtist()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddArtist(Artist A)
		{
			_artistManager.TAdd(A);
			return RedirectToAction("Index", "ArtistAdmin");
		}
	}
}
