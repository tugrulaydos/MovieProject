using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using MessagePack.Resolvers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieProject.Models;
using System.Collections.Immutable;
using System.Security.Cryptography.Xml;

namespace MovieProject.Controllers
{
	public class MovieDetailController : Controller
	{
		FilmManager _FilmManager = new FilmManager(new EFFilmDal());

        CommentManager _commentManager = new CommentManager(new EFCommentDal());

		public IActionResult Index(int id)
		{
            var c = new ContextMovieDB();

            Films_Comments fc1 = new Films_Comments();

            ViewBag.Value = _FilmManager.GetFilCtegoryByID(id);

            var ValueComment = _commentManager.GetCommentsWithFilmAndUser(id);

            var ValueMovie = _FilmManager.GetFilmCategoriesID(id);

            fc1.Value1 = ValueMovie;

            fc1.Value2 = ValueComment;           
            

            return View(fc1);
		}   
        
       

        public PartialViewResult DetailTop()  //Sayfaın üst kısmı
        {
          
            return PartialView();
        }

        public PartialViewResult DetailMiddle()  //Sayfanın orta ve alt kısmı
        {
           
            return PartialView();
        }
       

        public PartialViewResult DetailPartial3() //Pu Partial Detail Middle'ın içerisinde olacak.
        {


            return PartialView();
        }  
    }
}
