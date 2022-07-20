using AdminDashboard.Server.DTO;
using AdminDashboard.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminDashboard.Server.Repository.Interface
{
    public interface ISectorRepository
    {
        public Task<List<SectorDTO>> Get();
        public Task<SectorDTO> GetById(int id);
        public Task<ResponseModel> Add(SectorDTO dto);
        public Task<ResponseModel> Upate(SectorDTO dto);
    }
}
