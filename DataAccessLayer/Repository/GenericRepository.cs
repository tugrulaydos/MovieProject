using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
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

        public void Delete(T t)
        {
            //C.Remove(t);
            //C.SaveChanges();
        }

        public T GetByID(Expression<Func<T, bool>> filter)  //Tek Bir Entity Döndürür.
        {
            //return C.Set<T>().SingleOrDefault(filter);
            return null;
        }

        public List<T> GetList()  //Tüm Entity'leri Listeler.
        {
            //return C.Set<T>().ToList();
            return null;
        }

        public void insert(T t)  //Veri Ekleme.
        {
            //C.Add(t);
            //C.SaveChanges();
        }

        public void Update(T t) //Veri Güncelleme
        {
            //C.Update(t);
            //C.SaveChanges();

        }
    }
}
