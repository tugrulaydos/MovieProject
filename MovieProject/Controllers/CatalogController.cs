using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using MovieProject.Models;

namespace MovieProject.Controllers
{
    public class CatalogController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager(new EFCategoryDal());
        FilmManager _FilmManager = new FilmManager(new EFFilmDal());
        public IActionResult Index()
        {
            CatalogModel CM = new CatalogModel();
            CM.CategoriesForFilter = _categoryManager.TGetList();
            CM.Films = _FilmManager.FilmCategoryArtist();
            return View(CM);
        } 
             

        public PartialViewResult PartialTop()
        {

            return PartialView();
        }

        [HttpPost]
        public PartialViewResult PartialMiddle(int CategoryID)
        {

            return PartialView();
        }

        public PartialViewResult PartialBottom()
        {

            return PartialView();
        }


    }
}
