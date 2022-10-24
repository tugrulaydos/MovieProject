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
		public List<Film> FilmCategory();

		public Film GetFilCtegoryByID(int id);

		public List<Film> GetFilmCategoriesID(int id);  //Category ID'lerine göre Filmleri Getirecektir.

	}
}
