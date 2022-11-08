using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace MovieProject.Controllers
{
    public class CommentController : Controller
    {
        //CommentManager _CommentManager = new CommentManager(new EFCommentDal());

        ICommentService _CommentManager;

        public CommentController(ICommentService CommentManager)
        {
            this._CommentManager = CommentManager;

        }
        
        public IActionResult Index()
        {           


            return View();
        }
    }
}
