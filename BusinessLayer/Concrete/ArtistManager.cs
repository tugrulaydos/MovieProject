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
            throw new NotImplementedException();
        }

        public void TUpdate(Artist t)
        {
            throw new NotImplementedException();
        }
    }
}
