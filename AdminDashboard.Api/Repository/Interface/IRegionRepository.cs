using AdminDashboard.Api.Data.DTO;
using AdminDashboard.Api.Data.Models;

namespace AdminDashboard.Api.Repository.Interface
{
    public interface IRegionRepository
    {
        public Task<IEnumerable<RegionDTO>> Get();
        public RegionDTO GetById(int id);
        public ResponseModel Add(RegionDTO dto);
        public ResponseModel Upate(RegionDTO dto);
        void Save();
    }
}
