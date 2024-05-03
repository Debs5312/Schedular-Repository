using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProcessAPI.Repository;

namespace ProcessAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcessController : ControllerBase
    {
        private IProcessRepo _processRepo;
        private readonly IMapper _mapper;
        public ProcessController(IProcessRepo processRepo, IMapper mapper)
        {
            _mapper = mapper;
            _processRepo = processRepo;
        }


    }
}