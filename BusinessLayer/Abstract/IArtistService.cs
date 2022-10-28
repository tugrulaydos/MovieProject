using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IArtistService:IGenericService<Artist>
    {
        public List<Artist> GetArtistsByArtistID(int[] ArtistID); //Bu metodu kullanmadık silinebilir.
        


    }
}
