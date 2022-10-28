using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace MovieProject.Controllers
{
    public class CommentController : Controller
    {
        CommentManager _CommentManager = new CommentManager(new EFCommentDal());                
        
        public IActionResult Index()
        {           


            return View();
        }
    }
}
