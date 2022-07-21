using AdminDashboard.Api.Data.DTO;
using AdminDashboard.Api.Data.Models;
using AdminDashboard.Api.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdminDashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryRepository  _countryRepository;
        private readonly ILogger<AccountController> _logger;
        public CountryController(ICountryRepository  countryRepository, ILogger<AccountController> logger)
        {
            _countryRepository = countryRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryDTO>>> Get()
        {
            List<CountryDTO> list = new List<CountryDTO>();
            _logger.LogInformation("Attempted Get All Countries");
            list = (List<CountryDTO>)await _countryRepository.Get();
            _logger.LogInformation("Successfully got All Countries");

            return list;
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CountryDTO>> GetById(int id)
        {
            CountryDTO dto = new CountryDTO();
            _logger.LogInformation("Attempted Get  Country");
            dto = _countryRepository.GetById(id);
            _logger.LogInformation("Successfully got  Country");

            return dto;
        }
        [Route("Post")]
        [HttpPost]
        public async Task<ActionResult<ResponseModel>> Post([FromBody] CountryDTO dto)
        {
            ResponseModel response = new ResponseModel();

            _logger.LogInformation("Country  Attempt");
            response = _countryRepository.Add(dto);
            _logger.LogInformation("Country  Attempted");
            return response;
        }
        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<ResponseModel>> Update([FromBody] CountryDTO dto)
        {
            ResponseModel response = new ResponseModel();

            _logger.LogInformation("Update Country  Attempt");
            response = _countryRepository.Upate(dto);
            _logger.LogInformation("Update Country  Attempted");
            return response;
        }

        // DELETE api/<CountryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
