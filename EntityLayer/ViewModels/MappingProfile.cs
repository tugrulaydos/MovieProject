using AutoMapper;
using EntityLayer.Concrete;

namespace EntityLayer.ViewModels
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserVM, User>();
            CreateMap<User, UserVM>();
        }



    }
}
