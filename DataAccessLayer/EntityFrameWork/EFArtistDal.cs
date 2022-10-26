using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace DataAccessLayer.EntityFrameWork
{

    public class EFArtistDal : GenericRepository<Artist>, IArtistDal
    {
        
        public List<Artist> GetArtistByArtistID(int[] ArtistID)
        {
            var context = new ContextMovieDB();

            var values = context.Artists.Where(y => ArtistID.Contains(y.ID)).ToList();


            return values;
        }
    }
}
