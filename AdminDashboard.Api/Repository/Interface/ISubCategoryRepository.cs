using AdminDashboard.Api.Data.DTO;
using AdminDashboard.Api.Data.Models;

namespace AdminDashboard.Api.Repository.Interface
{
    public interface ISubCategoryRepository
    {
        public Task<IEnumerable<SubCategoryDTO>> Get();
        public SubCategoryDTO GetById(int id);
        public ResponseModel Add(SubCategoryDTO dto);
        public ResponseModel Upate(SubCategoryDTO dto);
        void Save();
    }
}
