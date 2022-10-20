using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class FilmCategory
    {
        public int ID { get; set; }

        public int FilmID { get; set; }

        public int CategoryID { get; set; }

        public  Film FilmFK { get; set; }

        public Category CategoryFK { get; set; }
    }
}
