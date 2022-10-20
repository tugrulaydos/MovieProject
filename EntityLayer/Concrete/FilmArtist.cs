using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class FilmArtist
    {              

        public int ArtistID{ get; set; }

        public int FilmID { get; set; }

        public Artist ArtistFK { get; set; }

        public Film FilmFK { get; set; }      

       
    }
}
