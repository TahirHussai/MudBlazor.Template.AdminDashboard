using AdminDashboard.Server.DTO;
using AdminDashboard.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminDashboard.Server.Repository.Interface
{
    public interface IRegionRepository
    {
        public Task<List<RegionDTO>> Get();
        public Task<RegionDTO> GetById(int id);
        public Task<ResponseModel> Add(RegionDTO dto);
        public Task<ResponseModel> Upate(RegionDTO dto);
    }
}
