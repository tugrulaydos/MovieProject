using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Watched
    {
        [Key]
        public int WatchedID { get; set; }

        public int UserID { get; set; }

        public int FilmID { get; set; }

        public double Raiting { get; set; }

        public Film FilmFK { get; set; }

        public User UserFK { get; set; }

    }
}
