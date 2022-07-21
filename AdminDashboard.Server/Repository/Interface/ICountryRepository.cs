using AdminDashboard.Server.DTO;
using AdminDashboard.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminDashboard.Server.Repository.Interface
{
    public interface ICountryRepository
    {
        public Task<List<CountryDTO>> Get();
        public Task<CountryDTO> GetById(int id);
        public Task<ResponseModel> Add(CountryDTO dto);
        public Task<ResponseModel> Upate(CountryDTO dto);
    }
}
