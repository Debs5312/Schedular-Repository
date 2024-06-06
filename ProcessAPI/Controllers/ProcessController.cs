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
                return StatusCode(201, processlist);
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

        [HttpGet("Get/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                Process process = await _processRepo.getSingleProcess(id);
                ProcessDTO processDTO = _mapper.Map<ProcessDTO>(process);
                return Ok(processDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] ProcessDTO processDTO)
        {
            Process processToUpdate = _mapper.Map<Process>(processDTO);
            try
            {
                Process process = await _processRepo.getSingleProcess(id);
                if(process == null) {
                    return StatusCode(404, "ID is invalid");
                }
                long updatedCount = await _processRepo.updateProcess(processToUpdate, id);
                if(updatedCount == 0)
                {
                    return StatusCode(500, "Problem in Database update. Please check DB connection.");
                }

                return Ok("Updated Document");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

    }
}