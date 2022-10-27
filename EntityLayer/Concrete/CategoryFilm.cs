using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class CategoryFilm
    {
        public int CategoryID { get; set; }

        public Category Category { get; set; }

        public int FilmID { get; set; }

        public Film Film { get; set; }

    }
}
