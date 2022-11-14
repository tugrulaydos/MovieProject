using BusinessLayer.Abstract;
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
using System.Text.Json;

namespace MovieProject.Controllers
{
    public class CatalogController : Controller
    {
        private static int _GenreID;
       
        
        private readonly ICategoryService _categoryManager;

        private readonly IFilmService _FilmManager;        

        private readonly IAjaxService _ajaxManager;       
               


        public CatalogController(IAjaxService ajaxManager,ICategoryService categoryManager, IFilmService FilmManager)
        {
           
            this._ajaxManager = ajaxManager;
            this._categoryManager = categoryManager;
            this._FilmManager = FilmManager;
        }

        public IActionResult Temp()
        {

            return RedirectToAction("Index","Catalog");

        }

        
        public IActionResult Index()
        {                                      
           
            

            CatalogModel CM = new CatalogModel();
            
            if (_GenreID!=0)
            {
                List<Film> Movies = _ajaxManager.GetFilmByGenreID(_GenreID);
                //CatalogModel CM = new CatalogModel();
                CM.Films = Movies;
                CM.CategoriesForFilter = _categoryManager.TGetList();

            }
            else
            {
                //CatalogModel CM = new CatalogModel();
                CM.CategoriesForFilter = _categoryManager.TGetList();
                CM.Films = _FilmManager.FilmCategoryArtist();

            }
                  

            

            return View(CM);
        }


        [HttpPost]
        public  IActionResult Genre(int GenreID)  //Film Türü
        {                        

            //List<Film> Movies = _ajaxManager.GetFilmByGenreID(GenreID);

            //CatalogModel CM = new CatalogModel();

            //CM.Films = Movies;

            //CM.CategoriesForFilter = _categoryManager.TGetList();


            _GenreID = GenreID;

            return RedirectToAction("Temp", "Catalog");



        }

        [HttpPost]
        public IActionResult Imdb(ImdbFilter Filter)  //FilmImdb
        {
            Filter.ImdbMinValue = Filter.ImdbMinValue / 10;
            Filter.ImdbMaxValue = Filter.ImdbMaxValue / 10;

            List<Film> Movies = _ajaxManager.GetFilmByImdb(Filter);

            CatalogModel CM = new CatalogModel();
            CM.Films = Movies;
            CM.CategoriesForFilter = _categoryManager.TGetList();


            return View();


        }

        [HttpPost]
        public IActionResult ReleaseYear(YearFilter Filter) //Vizyon Tarihi.
        {
            List<Film> Movies = _ajaxManager.GetFilmByYear(Filter);

            CatalogModel CM = new CatalogModel();
            CM.Films = Movies;
            CM.CategoriesForFilter = _categoryManager.TGetList();



            return View();
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
