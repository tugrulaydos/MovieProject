
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace MovieProject.ViewComponents
{
	public class LastFilmsViewComponent:ViewComponent
	{
		//FilmManager _filmManager = new FilmManager(new EFFilmDal());

		IFilmService _filmManager;

        IMemoryCache _memoryCache;

        public LastFilmsViewComponent(IMemoryCache memoryCache,IFilmService filmManager)
		{
			_memoryCache = memoryCache;

			this._filmManager = filmManager;

			Set();
		}

		public void Set()
		{
			var MovieList = _filmManager.GetFilmCategoryArtistTake6();

			_memoryCache.Set("Movies", MovieList, new MemoryCacheEntryOptions
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
