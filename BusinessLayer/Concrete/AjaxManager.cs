using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AjaxManager:IAjaxService
    {
        IAjaxDal _ajaxDal;
        public AjaxManager(IAjaxDal ajaxDal)
        {
            _ajaxDal = ajaxDal;
        }

        public List<Film> GetFilmByGenreID(int ID)
        {

            return _ajaxDal.GetFilmByGenreID(ID);
        }

        public List<Film> GetFilmByImdb(ImdbFilter filter)
        {
            return _ajaxDal.GetFilmByImdb(filter);
        }

        public List<Film> GetFilmByYear(YearFilter filter)
        {
            return _ajaxDal.GetFilmByYear(filter);
        }
    }
}
