using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        //MovieDBContext C = new MovieDBContext();

        private ContextMovieDB _context = null;

        private DbSet<T> table = null;

        public GenericRepository()
        {
            _context = new ContextMovieDB();
            table = _context.Set<T>();                         
        }
        public GenericRepository(ContextMovieDB context, DbSet<T> table)
        {
            _context = context;
            this.table = table;
        }

        public void Delete(T t)
        {
            table.Remove(t);
            _context.SaveChanges();
            //C.Remove(t);
            //C.SaveChanges();
        }

        public T GetByID(Expression<Func<T, bool>> filter)  //Tek Bir Entity Döndürür.
        {
            //return C.Set<T>().SingleOrDefault(filter);
            return table.FirstOrDefault(filter);
        }

        public List<T> GetList()  //Tüm Entity'leri Listeler.
        {
            //return C.Set<T>().ToList();
            return table.ToList();
        }

        public void insert(T t)  //Veri Ekleme.
        {
            //C.Add(t);
            //C.SaveChanges();
            table.Add(t);
            _context.SaveChanges();
        }

        public void Update(T t) //Veri Güncelleme
        {
            //C.Update(t);
            table.Update(t);
            _context.SaveChanges();
        }

       
    }
}
