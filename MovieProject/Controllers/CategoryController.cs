﻿using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFrameWork;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MovieProject.Controllers
{
    public class CategoryController : Controller
    {
        
        //CategoryManager _categoryManager = new CategoryManager(new EFCategoryDal());

        ICategoryService _categoryManager;
        public CategoryController(ICategoryService categoryService)
        {
            this._categoryManager = categoryService;
        }
        public IActionResult Index()
        {
            var values = _categoryManager.TGetList();
            
            return View(values);
        }

    

        public IActionResult AddCategory()
        {

            return View();

        }

        [HttpPost]
        public IActionResult AddCategory(Category c1)
        {
            _categoryManager.TAdd(c1);
            return RedirectToAction("Index", "Category");
        }

    }
}
