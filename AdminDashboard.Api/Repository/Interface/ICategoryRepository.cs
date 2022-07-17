using AdminDashboard.Api.Data.DTO;
using AdminDashboard.Api.Data.Models;

namespace AdminDashboard.Api.Repository.Interface
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<CategoryDTO>> Get();
        public CategoryDTO GetById(int id);
        public ResponseModel Add(CategoryDTO dto);
        public ResponseModel Upate(CategoryDTO dto);
        void Save();
    }
}
