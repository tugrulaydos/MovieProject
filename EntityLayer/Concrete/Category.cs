using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        public Category()
        {
            Films = new HashSet<Film>();
        }

        [Key]
        public int ID { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        public ICollection<Film> Films { get; set; }

       

      

    }
}
