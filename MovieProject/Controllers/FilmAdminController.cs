using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieProject.Models;
using System.ComponentModel;
using System.Text;

namespace MovieProject.Controllers
{
    public class FilmAdminController : Controller
    {
        FilmManager _filmManager = new FilmManager(new EFFilmDal());

        CategoryManager _categoryManager = new CategoryManager(new EFCategoryDal());

        ArtistManager _artistManager = new ArtistManager(new EFArtistDal());

      
        public IActionResult Index()
        {
            var values = _filmManager.FilmCategoryArtist();

            return View(values);
        }

        public IActionResult MovieDetail(int id)
        {
            var value = _filmManager.GetFilmByFilmID(id);

            return View(value);

        }

        public IActionResult UpdateMovie(Film f1)
        {            

            _filmManager.TUpdate(f1);



            return RedirectToAction("Index");
        }

        public IActionResult AddMovie()
        {
            ViewBag.Category = _categoryManager.TGetList(); //Category Listesi.

            ViewBag.Artists = _artistManager.TGetList(); //Artist Listesi         

            return View();
        }

        [HttpPost]
        public  IActionResult AddMovie(Film f,int[] GenreID, int[] ArtistID)
        {

            //var ValueCategories = _categoryManager.GetCategoriesByCategoryID(GenreID);

            //var ValueArtist = _artistManager.GetArtistsByArtistID(ArtistID);


            _filmManager.ADDFilm(f,GenreID,ArtistID);
           

            return RedirectToAction("Index", "FilmAdmin");
        }
    }
}
