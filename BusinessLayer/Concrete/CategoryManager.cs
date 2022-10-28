using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            this._categoryDal = categoryDal;

        }
        public Category GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategoriesByCategoryID(int[] _categoryID)
        {
            return _categoryDal.GetCategoriesByCategoryID(_categoryID);
        }

        public List<Category> GetCategoriesByCategoryID(List<int> _categoryID)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Category t)
        {
            _categoryDal.insert(t);
        }

        public void TDelete(Category t)
        {
            throw new NotImplementedException();
        }

        public List<Category> TGetList()
        {
            return _categoryDal.GetList();
        }

        public void TUpdate(Category t)
        {
            throw new NotImplementedException();
        }
    }
}
