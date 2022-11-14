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
        
        
        public List<Film> GetFilmByGenreID(int ID,double ImdbMax,double ImdbMin)
        {
            var c = new ContextMovieDB();

            var movies = c.Films.Include(x => x.Categories).ThenInclude(y => y.Category)
                .Where(a => a.Categories.Any(b => b.Category.ID == ID) && a.IMDBRaiting >= ImdbMin && a.IMDBRaiting <= ImdbMax).ToList();            

            return movies;
        }

        
    }
}
