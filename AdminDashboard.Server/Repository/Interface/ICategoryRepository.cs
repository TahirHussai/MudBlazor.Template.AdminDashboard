using AdminDashboard.Server.DTO;
using AdminDashboard.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminDashboard.Server.Repository.Interface
{
    public interface ICategoryRepository
    {
        public Task<List<CategoryDTO>> Get();
        public Task<CategoryDTO> GetById(int id);
        public Task<ResponseModel> Add(CategoryDTO dto);
        public Task<ResponseModel> Upate(CategoryDTO dto);
    }
}
