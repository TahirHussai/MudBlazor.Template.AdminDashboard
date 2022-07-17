using AdminDashboard.Api.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using AdminDashboard.Api.Data.DTO;
using AdminDashboard.Api.Data.Models;
using AdminDashboard.Api.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace AdminDashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository  _addressRepository;
        private readonly ILogger<AccountController> _logger;
        public AddressController(IAddressRepository addressRepository, ILogger<AccountController> logger)
        {
            _addressRepository = addressRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AddressDTO>>> Get()
        {
            List<AddressDTO> list = new List<AddressDTO>();
            _logger.LogInformation("Attempted Get All Address");

            list = (List<AddressDTO>)await _addressRepository.Get();
            _logger.LogInformation("Successfully got All Address");

            return list;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AddressDTO>> GetById(int id)
        {
            AddressDTO dto = new AddressDTO();
            _logger.LogInformation("Attempted Get  Address");
            dto = _addressRepository.GetById(id);
            _logger.LogInformation("Successfully got  Address");

            return dto;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel>> Post([FromBody] AddressDTO dto)
        {
            ResponseModel response = new ResponseModel();

            _logger.LogInformation("Address  Attempt");
            response = _addressRepository.Add(dto);
            _logger.LogInformation("Address  Attempted");
            return response;
        }

        [HttpPut]
        public async Task<ActionResult<ResponseModel>> Update([FromBody] AddressDTO dto)
        {
            ResponseModel response = new ResponseModel();

            _logger.LogInformation("Update Address  Attempt");
            response = _addressRepository.Upate(dto);
            _logger.LogInformation("Update Address  Attempted");
            return response;
        }

        // DELETE api/<AddressController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
