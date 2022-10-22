﻿using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFrameWork
{
	public class EFFilmDal : GenericRepository<Film>, IFilmDal
	{
		
		public List<Film> GetFilmCategory() 
		{
            var c = new ContextMovieDB();

            var values =  c.Films.Include(x => x.Categories).ToList();

			return values;

        }		

		public Film GetFilmCategoryByID(Expression<Func<Film, bool>> filter)
		{

			var c = new ContextMovieDB();
			

			return c.Films.Include(x=>x.Categories).FirstOrDefault(filter);

		}
	}
}
