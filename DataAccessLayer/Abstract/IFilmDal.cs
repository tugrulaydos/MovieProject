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
		public List<Film> GetFilmCategory();

		public Film GetFilmCategoryByID(Expression<Func<Film, bool>> filter);

		public List<Film> GetFilmCategoriesByID(int id);  //Seçilen Film ID'sinin sahip olduğu kategoriye göre ilgili kategoriye sahip olan diğer filmleri getirir.

		public Film GetFilmByFilmID(Expression<Func<Film, bool>> filter);

      



    }
}
