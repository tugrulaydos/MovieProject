using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class WatchList
    {
        public int WatchListID { get; set; }
        
        public int UserID { get; set; }

        public int FilmID { get; set; }

        public Film FilmFK { get; set; }

        public User UserFK { get; set; }

    }
}
