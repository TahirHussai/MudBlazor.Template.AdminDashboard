using AdminDashboard.Api.Data.DTO;
using AdminDashboard.Api.Data.Models;
using AdminDashboard.Api.Repository.Interface;
using AdminDashboard.APi.Data;

namespace AdminDashboard.Api.Repository.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ResponseModel Add(CategoryDTO dto)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                LuCategory model = new LuCategory();
                model.vchVal = dto.vchVal;
                model.vchDesc = dto.vchDesc;

                _dbContext.LuCategories.Add(model);
                Save();
                response.IsSuccess = true;
                response.ResponseMessage = "success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ResponseMessage = ex.ToString();
            }
            return response;
        }

        public async Task<IEnumerable<CategoryDTO>> Get()
        {
            List<CategoryDTO> listdto = new List<CategoryDTO>();
          


                var list = _dbContext.LuCategories.ToList();
                if (list != null && list.Count() > 0)
                {
                    foreach (var item in list)
                    {
                        var obj = new CategoryDTO();
                        obj.ID = item.ID;
                        obj.vchVal = item.vchVal;
                        obj.vchDesc = item.vchDesc;
                        listdto.Add(obj);
                    }
                }
            
            return listdto;
        }

        public CategoryDTO GetById(int id)
        {
            CategoryDTO dto = new CategoryDTO();
            var model = _dbContext.LuCategories.Where(a => a.ID == id).FirstOrDefault();
            if (model != null)
            {
                dto.ID = model.ID;
                dto.vchVal = model.vchVal;
                dto.vchDesc = model.vchDesc;
            }
            return dto;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public ResponseModel Upate(CategoryDTO dto)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                LuCategory model = new LuCategory();
                model.ID = dto.ID;
                model.vchVal = dto.vchVal;
                model.vchDesc = dto.vchDesc;
                _dbContext.LuCategories.Update(model);
                Save();
                response.IsSuccess = true;
                response.ResponseMessage = "success";
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.ResponseMessage = ex.ToString();
            }
            return response;
        }
    }
}
