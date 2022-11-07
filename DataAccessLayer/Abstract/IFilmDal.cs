using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
	public interface IFilmDal:IGenericDal<Film>
	{
		public List<Film> GetFilmCategoryArtist();

		public Film GetFilmCategoryByID(Expression<Func<Film, bool>> filter);

		public List<Film> GetFilmCategoriesByID(int id);  //Seçilen Film ID'sinin sahip olduğu kategoriye göre ilgili kategoriye sahip olan diğer filmleri getirir.

		public Film GetFilmByFilmID(Expression<Func<Film, bool>> filter);

		public void ADDFilm(Film _film, int[] CategoryIDs, int[] ArtistIDs);

		public List<Film> GetFilmCategoryArtistTake6();

		public Film GetFilmCategoryArtistByID(Expression<Func<Film, bool>> filter); //Artist ve Category Dahil Tek Bir Film Entity'si Getirir.

		public void UpdateCategoryArtist(int FilmID, int[] GenreIDs, int[] ArtistIDs);





    }
}
