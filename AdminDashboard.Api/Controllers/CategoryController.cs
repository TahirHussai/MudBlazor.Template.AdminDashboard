using AdminDashboard.Api.Data.DTO;
using AdminDashboard.Api.Data.Models;
using AdminDashboard.Api.Repository.Interface;
using Microsoft.AspNetCore.Mvc;


namespace AdminDashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogger<AccountController> _logger;
        public CategoryController(ICategoryRepository categoryRepository, ILogger<AccountController> logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            List<CategoryDTO> list = new List<CategoryDTO>();
            _logger.LogInformation("Attempted Get All Categories");

            list = (List<CategoryDTO>)await _categoryRepository.Get();
            _logger.LogInformation("Successfully got All Categories");

            return list;
        }

       
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetById(int id)
        {
            CategoryDTO dto = new CategoryDTO();
            _logger.LogInformation("Attempted Get  Category");
            dto = _categoryRepository.GetById(id);
            _logger.LogInformation("Successfully got  Category");

            return dto;
        }
        [Route("Post")]
        [HttpPost]
        public async Task<ActionResult<ResponseModel>> Post([FromBody] CategoryDTO dto)
        {
            ResponseModel response = new ResponseModel();
          
                _logger.LogInformation("Category  Attempt");
                response =  _categoryRepository.Add(dto);
                _logger.LogInformation("Category  Attempted");
            return response;
        }

        [HttpPut]
        public async Task<ActionResult<ResponseModel>> Update([FromBody] CategoryDTO dto)
        {
            ResponseModel response = new ResponseModel();

            _logger.LogInformation("Update Category  Attempt");
            response = _categoryRepository.Upate(dto);
            _logger.LogInformation("Update Category  Attempted");
            return response;
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
       
    }
}
