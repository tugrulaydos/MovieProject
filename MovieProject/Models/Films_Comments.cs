using EntityLayer.Concrete;

namespace MovieProject.Models
{
	public class Films_Comments
	{
		public IEnumerable<Film> Value1 { get; set; }
		public IEnumerable<Comment> Value2 { get; set; }
	}
}
