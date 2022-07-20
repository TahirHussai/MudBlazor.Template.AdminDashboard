using AdminDashboard.Api.Data.DTO;
using AdminDashboard.Api.Data.Models;
using AdminDashboard.Api.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubRegionController : ControllerBase
    {
        private readonly ISubRegionRepository  _subRegionRepository;
        private readonly ILogger<AccountController> _logger;
        public SubRegionController(ISubRegionRepository  subRegionRepository, ILogger<AccountController> logger)
        {
            _subRegionRepository = subRegionRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubRegionDTO>>> Get()
        {
            List<SubRegionDTO> list = new List<SubRegionDTO>();
            _logger.LogInformation("Attempted Get All Sub Region");

            list = (List<SubRegionDTO>)await _subRegionRepository.Get();
            _logger.LogInformation("Successfully got All Sub Region");

            return list;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubRegionDTO>> GetById(int id)
        {
            SubRegionDTO dto = new SubRegionDTO();
            _logger.LogInformation("Attempted Get  Sub Region");
            dto = _subRegionRepository.GetById(id);
            _logger.LogInformation("Successfully got  Sub Region");

            return dto;
        }
        [Route("Post")]
        [HttpPost]
        public async Task<ActionResult<ResponseModel>> Post([FromBody] SubRegionDTO dto)
        {
            ResponseModel response = new ResponseModel();

            _logger.LogInformation("Sub Region  Attempt");
            response = _subRegionRepository.Add(dto);
            _logger.LogInformation("Sub Region  Attempted");
            return response;
        }
        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<ResponseModel>> Update([FromBody] SubRegionDTO dto)
        {
            ResponseModel response = new ResponseModel();

            _logger.LogInformation("Update Sub Region  Attempt");
            response = _subRegionRepository.Upate(dto);
            _logger.LogInformation("Update Sub Region  Attempted");
            return response;
        }

        // DELETE api/<SubRegionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
