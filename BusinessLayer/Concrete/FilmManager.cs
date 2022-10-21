using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	
	public class FilmManager : IFilmService
	{
		IFilmDal _filmDal;

		public FilmManager(IFilmDal filmDal)
		{
			_filmDal = filmDal;
		}

		public List<Film> FilmCategory()
		{
			return _filmDal.GetFilmCategory();
		}

		public Film GetByID(int id) //Tekil Veri Getirir.
		{
			return _filmDal.GetByID(x => x.ID ==id);
		}

		public void TAdd(Film t)
		{
			_filmDal.insert(t);
		}

		public void TDelete(Film t)
		{
			_filmDal.Delete(t);
		}

		public List<Film> TGetList() //Tüüm Entity'leri Döndürüyor.
		{
			return _filmDal.GetList();
		}

		public void TUpdate(Film t)
		{
			_filmDal.Update(t);
		}
	}
}
