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

            ViewBag.Category = _categoryManager.TGetList();

            ViewBag.Artists = _artistManager.TGetList(); //Artist Listesi   



            return View(value);

        }

        [HttpPost]
        public async Task<IActionResult> UpdateMovie(Film f1, int[] GenreIDs, int[] ArtistIDs)
        {
            var context = new ContextMovieDB();

            _filmManager.TUpdate(f1);

            Film? movie = await context.Films.Include(x => x.Categories).ThenInclude(y => y.Category).Include(a => a.Artists).ThenInclude(b => b.Artist).FirstOrDefaultAsync(x => x.ID == f1.ID);
            

            movie.ID = f1.ID;
            movie.Name = f1.Name;
            movie.Scenerio = f1.Scenerio;
            movie.RunningTime = f1.RunningTime;
            movie.Scenerio = f1.Scenerio;
            movie.Age = f1.Age;
            movie.Country = f1.Country;
            movie.Director = f1.Director;
            movie.Story = f1.Story;
            movie.ReleaseYear = f1.ReleaseYear;
            movie.Producer = f1.Producer;
            


            foreach (var category in movie.Categories)
            {
                movie.Categories.Remove(category);

            }

            foreach (var artist in movie.Artists)
            {
                movie.Artists.Remove(artist);

            }         


            foreach (var item in GenreIDs)
            {
                CategoryFilm CF = new CategoryFilm
                {
                    CategoryID = item,
                    Film = movie

                };

                movie.Categories.Add(CF);

            }

            foreach (var item in ArtistIDs)
            {
                ArtistFilm AF = new ArtistFilm
                {
                    ArtistID = item,
                    Film = movie
                };
                movie.Artists.Add(AF);
            }


            await context.SaveChangesAsync();

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
