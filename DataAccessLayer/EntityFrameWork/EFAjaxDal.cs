using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using EntityLayer.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFrameWork
{
    public class EFAjaxDal : IAjaxDal
    {
        //ContextMovieDB c;

        //public EFAjaxDal(ContextMovieDB _c)
        //{
        //    this.c = _c;

        //}
        
        public List<Film> GetFilmByGenreID(int ID)
        {
            var c = new ContextMovieDB();

            var movies = c.Films.Include(x => x.Categories).ThenInclude(y => y.Category)
                .Where(a => a.Categories.Any(b => b.Category.ID == ID)).ToList();            

            return movies;
        }

        public List<Film> GetFilmByImdb(ImdbFilter filter)
        {
            var c = new ContextMovieDB();

            var movies = c.Films.Include(x => x.Categories).ThenInclude(y => y.Category).
                Where(a => a.IMDBRaiting >= filter.ImdbMinValue && a.IMDBRaiting <= filter.ImdbMaxValue).ToList();

            return movies;
        }

        public List<Film> GetFilmByYear(YearFilter filter)
        {
            var c = new ContextMovieDB();

            var movies = c.Films.Include(x=>x.Categories).ThenInclude(y=>y.Category).
                Where(a => a.ReleaseYear >= filter.MinYear && a.ReleaseYear <= filter.MaxYear).ToList();

            return movies;            
        }
    }
}
