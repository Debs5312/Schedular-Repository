using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Models.API.ProcessAPI;
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
            _processRepo = processRepo;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                List<Process> processes = await _processRepo.getAllProcess();
                if (processes.Count == 0) return NotFound();
                List<ProcessDTO> processlist = new List<ProcessDTO>();
                _mapper.Map(processes, processlist);
                return Ok(processlist);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPost("AddProcess")]
        public async Task<IActionResult> AddProcess([FromBody] ProcessDTO processDTO)
        {
            Process process = new Process();
            _mapper.Map(processDTO, process);
            try
            {
                await _processRepo.AddProcess(process);
                _mapper.Map(process, processDTO);
                return Ok(processDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

    }
}