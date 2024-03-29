﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFrameWork
{
	public class EFFilmDal : GenericRepository<Film>, IFilmDal
	{
		public List<Film> GetFilmCategoriesByID(int id) 
		{
			var c = new ContextMovieDB();

			//var values1 = c.Films.Include(x => x.Categories).FirstOrDefault(y => y.ID == id); //Seçtiğimiz Film

			//List<int> IDCategories = new List<int>(); //Seçilen Filmin Kategori ID'lerini Bu Listeye Atacağız

			//foreach (var category in values1.Categories) //Category ID'si bu olan filmleri alacağız.
			//{
			//	IDCategories.Add(category.ID);
			//}			

			//var values2 = c.Films.Include(x => x.Categories.Where(y => IDCategories.Contains(y.ID))).ToList();

			//values2 = values2.Where(y => y.Categories.Count > 0).ToList();


			//return values2;

			var values1 = c.Films.Include(x => x.Categories).ThenInclude(y => y.Category).FirstOrDefault(z => z.ID == id); //Seçtiğimiz Film

            List<int> IDCategories = new List<int>(); //Seçilen Filmin Kategori ID'lerini Bu Listeye Atacağız

			foreach (var item in values1.Categories) //Category ID'si bu olan filmleri alacağız.
			{
                IDCategories.Add(item.Category.ID);

            }

            //var values2 = c.Films.Include(x => x.Categories.Where(y => IDCategories.Contains(y.Category.ID))).ToList();



            //values2 = values2.Where(a => a.Categories.Count > 0).ToList(); 


            var values2 = c.Films.Include(x => x.Categories).ThenInclude(y => y.Category).Where(z => z.Categories.Any(a => IDCategories.Contains(a.CategoryID))).ToList();


            values2.Remove(values1);


            return values2;			
		}

		public List<Film> GetFilmCategoryArtist()  
		{
            var c = new ContextMovieDB();

			//var values = c.Films.Include(x => x.Categories).Include(x => x.Artists).ToList(); //Category ve Artist'i de getirecektir.

			var values = c.Films.Include(x => x.Categories).ThenInclude(z => z.Category).Include(a => a.Artists).ThenInclude(b => b.Artist).ToList();
			

			return values;

        }		

		public Film GetFilmCategoryByID(Expression<Func<Film, bool>> filter)
		{

			var c = new ContextMovieDB();


			//return c.Films.Include(x=>x.Categories).FirstOrDefault(filter);

			return c.Films.Include(x => x.Categories).ThenInclude(y => y.Category).FirstOrDefault(filter);

		}

		public Film GetFilmByFilmID(Expression<Func<Film,bool>> filter)
		{
			var c = new ContextMovieDB();

			//return c.Films.Include(y => y.Categories).Include(z=>z.Artists).FirstOrDefault(filter);

			return c.Films.Include(x => x.Categories).ThenInclude(y => y.Category).Include(a => a.Artists).ThenInclude(b => b.Artist).FirstOrDefault(filter);

		}

		public void ADDFilm(Film _film, int[] CategoryIDs, int[] ArtistIDs)
		{
			var c = new ContextMovieDB();

            foreach (var item in CategoryIDs)
            {
                CategoryFilm _categoryFilm = new CategoryFilm()
                {
                    CategoryID = item,
                    Film = _film
                };

                c.CategoryFilms.Add(_categoryFilm);
            }

            foreach (var item in ArtistIDs)
            {
                ArtistFilm _artistFilm = new ArtistFilm()
                {
                    ArtistID = item,
                    Film = _film
                };
                c.ArtistFilms.Add(_artistFilm);
            }

            c.Films.Add(_film);

            c.SaveChanges();			


        }

		public List<Film> GetFilmCategoryArtistTake6()
		{
            var c = new ContextMovieDB();

			return c.Films.Include(x => x.Artists).ThenInclude(y => y.Artist).Include(a => a.Categories).ThenInclude(b => b.Category).Take(6).OrderByDescending(y=>y.ID).ToList();


        }

		public Film GetFilmCategoryArtistByID(Expression<Func<Film, bool>> filter)
		{
			var context = new ContextMovieDB();

			return context.Films.Include(x => x.Categories).Include(y => y.Artists).FirstOrDefault(filter);
        }

		public void UpdateCategoryArtist(int FilmID, int[] GenreIDs, int[] ArtistIDs)
		{
            var context = new ContextMovieDB();
            Film? movie = context.Films.Include(x => x.Categories).ThenInclude(y => y.Category).Include(a => a.Artists).ThenInclude(b => b.Artist).FirstOrDefault(x => x.ID == FilmID);


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

            context.SaveChanges();

        }

		
	}
}
