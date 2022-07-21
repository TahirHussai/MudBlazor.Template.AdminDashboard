using AdminDashboard.Api.Data.DTO;
using AdminDashboard.Api.Data.Models;

namespace AdminDashboard.Api.Repository.Interface
{
    public interface ICountryRepository
    {
        public Task<IEnumerable<CountryDTO>> Get();
        public CountryDTO GetById(int id);
        public ResponseModel Add(CountryDTO dto);
        public ResponseModel Upate(CountryDTO dto);
        void Save();
    }
}
