using EntityLayer.Concrete;

namespace MovieProject.Models
{
	public class CatalogModel
	{
		public ICollection<Category> CategoriesForFilter { get; set; }

		public ICollection<Film> Films { get; set; }


	}
}
