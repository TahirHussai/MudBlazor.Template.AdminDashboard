using AdminDashboard.Server.DTO;
using AdminDashboard.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminDashboard.Server.Repository.Interface
{
    public interface ISubCategoryRepository
    {
        public Task<List<SubCategoryDTO>> Get();
        public Task<SubCategoryDTO> GetById(int id);
        public Task<ResponseModel> Add(SubCategoryDTO dto);
        public Task<ResponseModel> Upate(SubCategoryDTO dto);
    }
}
