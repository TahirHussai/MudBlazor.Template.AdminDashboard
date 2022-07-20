using AdminDashboard.Api.Data.DTO;
using AdminDashboard.Api.Data.Models;
using AdminDashboard.Api.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdminDashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionRepository  _regionRepository;
        private readonly ILogger<AccountController> _logger;
        public RegionController(IRegionRepository  regionRepository, ILogger<AccountController> logger)
        {
            _regionRepository = regionRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegionDTO>>> Get()
        {
            List<RegionDTO> list = new List<RegionDTO>();
            _logger.LogInformation("Attempted Get All  Region");

            list = (List<RegionDTO>)await _regionRepository.Get();
            _logger.LogInformation("Successfully got All  Region");

            return list;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RegionDTO>> GetById(int id)
        {
            RegionDTO dto = new RegionDTO();
            _logger.LogInformation("Attempted Get   Region");
            dto = _regionRepository.GetById(id);
            _logger.LogInformation("Successfully got   Region");

            return dto;
        }
        [Route("Post")]
        [HttpPost]
        public async Task<ActionResult<ResponseModel>> Post([FromBody] RegionDTO dto)
        {
            ResponseModel response = new ResponseModel();

            _logger.LogInformation(" Region  Attempt");
            response = _regionRepository.Add(dto);
            _logger.LogInformation(" Region  Attempted");
            return response;
        }
        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<ResponseModel>> Update([FromBody] RegionDTO dto)
        {
            ResponseModel response = new ResponseModel();

            _logger.LogInformation("Update ub Region  Attempt");
            response = _regionRepository.Upate(dto);
            _logger.LogInformation("Update  Region  Attempted");
            return response;
        }

        // DELETE api/<RegionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
