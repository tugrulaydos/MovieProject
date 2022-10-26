using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFrameWork
{
    public class EFCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public List<Category> GetCategoriesByCategoryID(List<int> _categoryID)
        {
            var c = new ContextMovieDB();          



           var values = c.Categories.Where(y=>_categoryID.Contains(y.ID)).ToList();
 
           return values;
            

            
        }
    }
}
