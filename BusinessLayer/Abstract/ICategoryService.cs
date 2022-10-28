using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService:IGenericService<Category>
    {
        public List<Category> GetCategoriesByCategoryID(int[] _categoryID);  //ID'si listenin içerisindeki ID'lerle eşleşen Category'leri listeleyecektir.
        //Bu metodu henüz kuanmadık silinebilir.
    }
}
