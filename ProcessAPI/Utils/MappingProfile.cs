using AutoMapper;
using Models.API.ProcessAPI;

namespace ProcessAPI.Utils
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProcessDTO, Process>();
            CreateMap<Process, ProcessDTO>();
        }
    }
}