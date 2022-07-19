using AdminDashboard.Api.Data.DTO;
using AdminDashboard.Api.Data.Models;
using AdminDashboard.Api.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdminDashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly ILogger<AccountController> _logger;
        public SubCategoryController(ISubCategoryRepository subCategoryRepository, ILogger<AccountController> logger)
        {
            _subCategoryRepository = subCategoryRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubCategoryDTO>>> Get()
        {
            List<SubCategoryDTO> list = new List<SubCategoryDTO>();
            _logger.LogInformation("Attempted Get All Sub Categories");

            list = (List<SubCategoryDTO>)await _subCategoryRepository.Get();
            _logger.LogInformation("Successfully got All Sub Categories");

            return list;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubCategoryDTO>> GetById(int id)
        {
            SubCategoryDTO dto = new SubCategoryDTO();
            _logger.LogInformation("Attempted Get Sub  Category");
            dto = _subCategoryRepository.GetById(id);
            _logger.LogInformation("Successfully got  Sub Category");

            return dto;
        }
        [Route("Post")]
        [HttpPost]
        public async Task<ActionResult<ResponseModel>> Post([FromBody] SubCategoryDTO dto)
        {
            ResponseModel response = new ResponseModel();

            _logger.LogInformation("Sub Category  Attempt");
            response = _subCategoryRepository.Add(dto);
            _logger.LogInformation("Sub Category  Attempted");
            return response;
        }
        [Route("Update")]
        [HttpPut]
        public async Task<ActionResult<ResponseModel>> Update([FromBody] SubCategoryDTO dto)
        {
            ResponseModel response = new ResponseModel();

            _logger.LogInformation("Update Sub Category  Attempt");
            response = _subCategoryRepository.Upate(dto);
            _logger.LogInformation("Update Sub Category  Attempted");
            return response;
        }

        // DELETE api/<SubCategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
