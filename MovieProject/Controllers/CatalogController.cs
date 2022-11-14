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
        private static int sayac = 0;
       
        private static int _GenreID = 0;

        private static double _IMDBMin = 0;

        private static double _IMDBMax = 0;

        
        private readonly ICategoryService _categoryManager;

        private readonly IFilmService _FilmManager;        

        private readonly IAjaxService _ajaxManager;       
               


        public CatalogController(IAjaxService ajaxManager,ICategoryService categoryManager, IFilmService FilmManager)
        {
           
            this._ajaxManager = ajaxManager;
            this._categoryManager = categoryManager;
            this._FilmManager = FilmManager;
           
        }

        public IActionResult Temp(FilterVM _filterVM)
        {

            _GenreID = _filterVM.GenreID;

            _IMDBMax = _filterVM.ImdbMaxValue / 10;

            _IMDBMin = _filterVM.ImdbMinValue / 10;

            sayac = 2;
         
            return RedirectToAction("Index", "Catalog");
        }

       
        public IActionResult Index()        
        {                                 
                      

            CatalogModel CM = new CatalogModel();
            
            if (sayac != 0)
            {
                List<Film> Movies = _ajaxManager.GetFilmByGenreID(_GenreID,_IMDBMax,_IMDBMin);
                //CatalogModel CM = new CatalogModel();
                CM.Films = Movies;
                CM.CategoriesForFilter = _categoryManager.TGetList();
                sayac -= 1;
                

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
        public  IActionResult Genre(FilterVM _filterVM)  //Film Türü
        {                        

            //List<Film> Movies = _ajaxManager.GetFilmByGenreID(GenreID);

            //CatalogModel CM = new CatalogModel();

            //CM.Films = Movies;

            //CM.CategoriesForFilter = _categoryManager.TGetList();
            //

            _GenreID = _filterVM.GenreID;

            _IMDBMax = _filterVM.ImdbMaxValue/10;

            _IMDBMin = _filterVM.ImdbMinValue/10;

            return RedirectToAction("Temp", "Catalog",_filterVM);



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
