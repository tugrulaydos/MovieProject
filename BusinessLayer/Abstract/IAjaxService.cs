using EntityLayer.Concrete;
using EntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAjaxService
    {
        public List<Film> GetFilmByGenreID(int ID);
        public List<Film> GetFilmByImdb(ImdbFilter filter);
        public List<Film> GetFilmByYear(YearFilter filter);     

    }
}
