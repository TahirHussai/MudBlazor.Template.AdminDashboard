using AdminDashboard.Server.DTO;
using AdminDashboard.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminDashboard.Server.Repository.Interface
{
    public interface ISubRegionRepository
    {
        public Task<List<SubRegionDTO>> Get();
        public Task<SubRegionDTO> GetById(int id);
        public Task<ResponseModel> Add(SubRegionDTO dto);
        public Task<ResponseModel> Upate(SubRegionDTO dto);
    }
}
