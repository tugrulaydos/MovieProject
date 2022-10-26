using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    
    public class ArtistManager : IArtistService
    {
        IArtistDal _artistDal;

        public ArtistManager(IArtistDal artistDal)
        {
            _artistDal = artistDal;
                  
        }

        public List<Artist> GetArtistsByArtistID(int[] ArtistID)
        {
            return _artistDal.GetArtistByArtistID(ArtistID);
        }

        public Artist GetByID(int ID)
        {
            throw new NotImplementedException();
        }

        public void TAdd(Artist t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Artist t)
        {
            throw new NotImplementedException();
        }

        public List<Artist> TGetList()
        {
            return _artistDal.GetList();
        }

        public void TUpdate(Artist t)
        {
            throw new NotImplementedException();
        }
    }
}
