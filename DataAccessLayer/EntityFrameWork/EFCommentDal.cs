using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFrameWork
{
    public class EFCommentDal : GenericRepository<Comment>, ICommentDal
    {
        public List<Comment> GetCommentsWithFilmAndUser(int id)
        {
            var c = new ContextMovieDB();

            return c.Comments.Include(x => x.User).Include(y => y.Film).Where(z => z.Film.ID == id).ToList();
            
        }
    }
}
