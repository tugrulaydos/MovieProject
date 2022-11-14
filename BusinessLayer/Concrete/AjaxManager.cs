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
             

        public List<Film> GetFilmByGenreID(int ID, double ImdbMax, double ImdbMin)
        {
            return _ajaxDal.GetFilmByGenreID(ID,ImdbMax,ImdbMin);
        }

      
    }
}
