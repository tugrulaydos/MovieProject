﻿using BusinessLayer.Abstract;
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
        public Category GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Category t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Category t)
        {
            throw new NotImplementedException();
        }

        public List<Category> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Category t)
        {
            throw new NotImplementedException();
        }
    }
}
