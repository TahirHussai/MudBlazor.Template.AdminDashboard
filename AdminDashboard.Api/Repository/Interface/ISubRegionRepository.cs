using AdminDashboard.Api.Data.DTO;
using AdminDashboard.Api.Data.Models;

namespace AdminDashboard.Api.Repository.Interface
{
    public interface ISubRegionRepository
    {
        public Task<IEnumerable<SubRegionDTO>> Get();
        public SubRegionDTO GetById(int id);
        public ResponseModel Add(SubRegionDTO dto);
        public ResponseModel Upate(SubRegionDTO dto);
        void Save();
    }
}
