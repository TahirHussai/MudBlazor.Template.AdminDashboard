using AdminDashboard.Api.Data.DTO;
using AdminDashboard.Api.Data.Models;
using AdminDashboard.Api.Repository.Interface;
using AdminDashboard.APi.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdminDashboard.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly IJobRepository _jobRepository;
        private readonly ILogger<AccountController> logger;
        private readonly IHttpClientFactory _client;
        private readonly ApplicationDbContext _dbContext;
        public JobController(ApplicationDbContext applicationDbContext, IHttpClientFactory httpClientFactory, ILogger<AccountController> logger, IJobRepository jobRepository)
        {
            this.logger = logger;
            _jobRepository = jobRepository;
            _client = httpClientFactory;
            _dbContext = applicationDbContext;  
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobDTO>>> Get()
        {
            logger.LogInformation("Attempted Get All Jobs");
            List<JobDTO> list = new List<JobDTO>();
            list = (List<JobDTO>)await _jobRepository.Get();
            logger.LogInformation("Successfully got All Job");
            return list;
        }

        // GET api/<JobController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<string>> Get(int id=0)
        {
            var request = new HttpRequestMessage(HttpMethod.Get
               , "https://countriesnow.space/api/v0.1/countries");

            var client = _client.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            var content =await  response.Content.ReadAsStringAsync();
            var d = JsonConvert.DeserializeObject<dynamic>(content);
            var data = d["data"];
            if (data !=null)
            {
                foreach (var item in data)
                {
                    var obj = new Countires();
                    obj.Abv = item["iso3"];
                    obj.CountryName = item["country"];
                    _dbContext.Countires.Add(obj);
                    _dbContext.SaveChanges();
                }

            }
            return " ";
        }

        [Route("Post")]
        [HttpPost]
        public async Task<ActionResult<bool>> Post([FromBody] JobDTO dto)
        {
            bool result = false;
            var location = GetControllerActionName();
            try
            {
                logger.LogInformation($"{location}: Job  Attempt from user ");
                result = _jobRepository.Add(dto);
            }
            catch (Exception e)
            {
                return InternalError($"{location}: {e.Message} - {e.InnerException}");
            }
            return result;
        }

        // PUT api/<JobController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<JobController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        private string GetControllerActionName()
        {
            var controller = ControllerContext.ActionDescriptor.ControllerName;
            var action = ControllerContext.ActionDescriptor.ActionName;

            return $"{controller}-{action}";
        }

        private ObjectResult InternalError(string message)
        {
            logger.LogError(message);

            return StatusCode(500, "Some thing went wrong please contact to administrator");
        }


    }
}
