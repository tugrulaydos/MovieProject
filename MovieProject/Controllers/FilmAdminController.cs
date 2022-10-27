﻿using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieProject.Models;
using System.ComponentModel;

namespace MovieProject.Controllers
{
    public class FilmAdminController : Controller
    {
        FilmManager _filmManager = new FilmManager(new EFFilmDal());

        CategoryManager _categoryManager = new CategoryManager(new EFCategoryDal());

        ArtistManager _artistManager = new ArtistManager(new EFArtistDal());
        public IActionResult Index()
        {
            var values = _filmManager.FilmCategory();

            return View(values);
        }

        public IActionResult MovieDetail(int id)
        {
            var value = _filmManager.GetFilmByFilmID(id);

            return View(value);

        }

        public IActionResult UpdateMovie(Film f1)
        {
            
            return RedirectToAction("Index");
        }

        public IActionResult AddMovie()
        {
            ViewBag.Category = _categoryManager.TGetList(); //Category Listesi.

            ViewBag.Artists = _artistManager.TGetList(); //Artist Listesi         

            return View();
        }

        [HttpPost]
        public  IActionResult AddMovie(Film f,List<int> GenreID, int[] ArtistOpt)
        {
            var c = new ContextMovieDB(); 
             
            var ValueCategories = _categoryManager.GetCategoriesByCategoryID(GenreID);

            var ValueArtist = _artistManager.GetArtistsByArtistID(ArtistOpt);

            ICollection<Category> c1 = (ICollection<Category>)ValueCategories; 

            //Film f1 = new Film()
            //{                
            //    Name = f.Name,
            //    Scenerio = f.Scenerio,
            //    Producer = f.Producer,
            //    Director = f.Director,
            //    IMDBRaiting = f.IMDBRaiting,
            //    Story = f.Story,
            //    İmageUrl = f.İmageUrl,
            //    Country = f.Country,
            //    ReleaseYear = f.ReleaseYear,
            //    RunningTime = f.RunningTime,
            //    Age = f.Age                           
               
               
            //};

            foreach(var item in GenreID)
            {
                CategoryFilm _categoryFilm = new CategoryFilm()
                {
                    CategoryID = item,
                    Film = f
                };

                c.CategoryFilms.Add(_categoryFilm);
            }

            foreach(var item in ArtistOpt)
            {
                ArtistFilm _artistFilm = new ArtistFilm()
                {
                    ArtistID = item,
                    Film = f
                };
                c.ArtistFilms.Add(_artistFilm);
            }            

             c.Films.Add(f);

             c.SaveChanges();



            return RedirectToAction("Index", "FilmAdmin");
        }
    }
}
