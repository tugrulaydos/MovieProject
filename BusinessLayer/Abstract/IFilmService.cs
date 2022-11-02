using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IFilmService:IGenericService<Film>
	{
		public List<Film> FilmCategoryArtist(); //Tüm Filmeleri Getireceğiz Artist ve Category tabloları dahil ediliyor.

		public Film GetFilCtegoryByID(int id);

		public List<Film> GetFilmCategoriesID(int id);  //Category ID'lerine göre Filmleri Getirecektir.

		public Film GetFilmByFilmID(int id); //Film ID'sine Göre İstenilen Filmi Getireceğiz.

		public void ADDFilm(Film _film, int[] _CatogoryIDs, int[] _ArtistIDs);

		public List<Film> GetFilmCategoryArtistTake6();
				

	}
}
