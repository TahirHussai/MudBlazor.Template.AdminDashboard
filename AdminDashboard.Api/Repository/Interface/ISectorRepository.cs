using AdminDashboard.Api.Data.DTO;
using AdminDashboard.Api.Data.Models;

namespace AdminDashboard.Api.Repository.Interface
{
    public interface ISectorRepository
    {
        public Task<IEnumerable<SectorDTO>> Get();
        public SectorDTO GetById(int id);
        public ResponseModel Add(SectorDTO dto);
        public ResponseModel Upate(SectorDTO dto);
        void Save();
    }
}
