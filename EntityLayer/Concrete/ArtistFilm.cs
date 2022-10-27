using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ArtistFilm
    {
        public int ArtistID { get; set; }
        public Artist Artist { get; set; }
        public int FilmID { get; set; }
        public Film Film { get; set; }

    }
}
