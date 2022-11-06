
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MovieProject.ViewComponents
{
	public class LastFilmsViewComponent:ViewComponent
	{
        FilmManager _filmManager = new FilmManager(new EFFilmDal());

        IMemoryCache _memoryCache;

        public LastFilmsViewComponent(IMemoryCache memoryCache)
		{
			_memoryCache = memoryCache;

			Set();
		}

		public void Set()
		{
			var MovieList = _filmManager.GetFilmCategoryArtistTake6();

			_memoryCache.Set("Movies6", MovieList, new MemoryCacheEntryOptions
			{
				AbsoluteExpiration = DateTime.Now.AddSeconds(20),

				SlidingExpiration = TimeSpan.FromSeconds(10),

				Priority = CacheItemPriority.Normal
			});
			
		}

        public IViewComponentResult Invoke()
		{
			//var values = _filmManager.GetFilmCategoryArtistTake6();

			if(_memoryCache.TryGetValue<List<Film>>("Movies",out List<Film> values))
			{
				var movies = _memoryCache.Get<List<Film>>("Movies");
				return View(movies);
			}


			return View();

		}


	}
}
