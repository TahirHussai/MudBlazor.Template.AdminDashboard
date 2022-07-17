using AdminDashboard.Api.Data.DTO;
using AdminDashboard.Api.Data.Models;
using AdminDashboard.Api.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdminDashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorController : ControllerBase
    {
        private readonly ISectorRepository  _sectorRepository;
        private readonly ILogger<AccountController> _logger;
        public SectorController(ISectorRepository sectorRepository, ILogger<AccountController> logger)
        {
            _sectorRepository = sectorRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SectorDTO>>> Get()
        {
            List<SectorDTO> list = new List<SectorDTO>();
            _logger.LogInformation("Attempted Get All Sector");

            list = (List<SectorDTO>)await _sectorRepository.Get();
            _logger.LogInformation("Successfully got All Sector");

            return list;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SectorDTO>> GetById(int id)
        {
            SectorDTO dto = new SectorDTO();
            _logger.LogInformation("Attempted Get Sector");
            dto = _sectorRepository.GetById(id);
            _logger.LogInformation("Successfully got  Sector");

            return dto;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel>> Post([FromBody] SectorDTO dto)
        {
            ResponseModel response = new ResponseModel();

            _logger.LogInformation("Sector Attempt");
            response = _sectorRepository.Add(dto);
            _logger.LogInformation("Sector  Attempted");
            return response;
        }

        [HttpPut]
        public async Task<ActionResult<ResponseModel>> Update([FromBody] SectorDTO dto)
        {
            ResponseModel response = new ResponseModel();

            _logger.LogInformation("Update Sector  Attempt");
            response = _sectorRepository.Upate(dto);
            _logger.LogInformation("Update Sector  Attempted");
            return response;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
