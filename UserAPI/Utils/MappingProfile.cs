using AutoMapper;
using Models.API.UserAPI;

namespace UserAPI.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
        }
    }
}