using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using EntityLayer.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using MovieProject.Models;
using System.Runtime.CompilerServices;

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

        [HttpPost]
        public  IActionResult Index(FilterVM fvm)
        {
            var c = new ContextMovieDB();

            fvm.ImdbMinValue = fvm.ImdbMinValue / 10;
            fvm.ImdbMaxValue = fvm.ImdbMaxValue / 10;

          
            var movies = c.Films.Include(x => x.Categories).ThenInclude(y => y.Category)
                .Where(a => a.Categories.Any(b => b.Category.ID == fvm.GenreID)).ToList();
            //var movies2 = movies.Where(a => a.Categories.Where(b => fvm.Genre.Contains(b.Category.CategoryName)).ToList();  

            CatalogModel CM = new CatalogModel();
            CM.Films = movies;
            CM.CategoriesForFilter = _categoryManager.TGetList();

            return null;

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
