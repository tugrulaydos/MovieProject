using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class FilmDirector
    {
        [Key]
        public int ID { get; set; }

        public int DirectorID { get; set; }

        public int FilmID { get; set; }

        public Director DirectorFK { get; set; }

        public Film FilmFK { get; set; }
    }
}
