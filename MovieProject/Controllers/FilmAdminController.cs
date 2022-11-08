using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using EntityLayer.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieProject.Models;
using NuGet.Packaging;
using System.ComponentModel;
using System.Text;

namespace MovieProject.Controllers
{
    public class FilmAdminController : Controller
    {
        //FilmManager _filmManager = new FilmManager(new EFFilmDal());

        //CategoryManager _categoryManager = new CategoryManager(new EFCategoryDal());

        //ArtistManager _artistManager = new ArtistManager(new EFArtistDal());

        IFilmService _filmManager;

        ICategoryService _categoryManager;

        IArtistService _artistManager;

        public FilmAdminController(IFilmService filManager, ICategoryService categoryManager, IArtistService artistManager)
        {
            _filmManager = filManager;
            _categoryManager = categoryManager;
            _artistManager = artistManager;
        }

      
        public IActionResult Index()
        {
            var values = _filmManager.FilmCategoryArtist();

            return View(values);
        }

        public IActionResult MovieDetail(int id)
        {
            var value = _filmManager.GetFilmByFilmID(id);

            ViewBag.Category = _categoryManager.TGetList();

            ViewBag.Artists = _artistManager.TGetList(); //Artist Listesi   



            return View(value);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateMovie(Film f1, int[] GenreIDs, int[] ArtistIDs)
        {
            var context = new ContextMovieDB();

            _filmManager.TUpdate(f1);


            _filmManager.UpdateCategoryArtist(f1.ID, GenreIDs, ArtistIDs);

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

            _filmManager.ADDFilm(f,GenreID,ArtistID);           

            return RedirectToAction("Index", "FilmAdmin");
        }
    }
}
