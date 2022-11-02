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

		public List<Film> FilmCategoryArtist()
		{
			return _filmDal.GetFilmCategoryArtist();
		}

		public Film GetByID(int id) //Tekil Veri Getirir.
		{
			return _filmDal.GetByID(x => x.ID ==id);
		}

		public Film GetFilCtegoryByID(int id)
		{
			return _filmDal.GetFilmCategoryByID(x => x.ID == id);
		}

		public Film GetFilmByFilmID(int id)
		{
			return _filmDal.GetFilmByFilmID(y=>y.ID==id);

        }

		public List<Film> GetFilmCategoriesID(int id)
		{
			return _filmDal.GetFilmCategoriesByID(id);
		}

		public void ADDFilm(Film _film, int[] _CatogoryIDs, int[] _ArtistIDs)
		{
		    _filmDal.ADDFilm(_film, _CatogoryIDs, _ArtistIDs);
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

		public List<Film> GetFilmCategoryArtistTake6()
		{
			return _filmDal.GetFilmCategoryArtistTake6();
		}
	}
}
