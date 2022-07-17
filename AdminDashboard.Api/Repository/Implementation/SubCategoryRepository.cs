using AdminDashboard.Api.Data.DTO;
using AdminDashboard.Api.Data.Models;
using AdminDashboard.Api.Repository.Interface;
using AdminDashboard.APi.Data;

namespace AdminDashboard.Api.Repository.Implementation
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public SubCategoryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ResponseModel Add(SubCategoryDTO dto)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                LuSubCategory model = new LuSubCategory();
                model.vchVal = dto.vchVal;
                model.vchDesc = dto.vchDesc;

                _dbContext.LuSubCategories.Add(model);
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

        public async Task<IEnumerable<SubCategoryDTO>> Get()
        {
            List<SubCategoryDTO> listdto = new List<SubCategoryDTO>();

                var list = _dbContext.LuSubCategories.ToList();
                if (list != null && list.Count() > 0)
                {
                    foreach (var item in list)
                    {
                        var obj = new SubCategoryDTO();
                        obj.SubCatID = item.SubCatID;
                        obj.vchVal = item.vchVal;
                        obj.vchDesc = item.vchDesc;
                        listdto.Add(obj);
                    }
                }
           
            return listdto;
        }

        public SubCategoryDTO GetById(int id)
        {
            SubCategoryDTO dto = new SubCategoryDTO();
            var model = _dbContext.LuSubCategories.Where(a => a.SubCatID == id).FirstOrDefault();
            if (model != null)
            {
                dto.SubCatID = model.SubCatID;
                dto.vchVal = model.vchVal;
                dto.vchDesc = model.vchDesc;
            }
            return dto;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public ResponseModel Upate(SubCategoryDTO dto)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                LuSubCategory model = new LuSubCategory();
                model.SubCatID = dto.SubCatID;
                model.vchVal = dto.vchVal;
                model.vchDesc = dto.vchDesc;
                _dbContext.LuSubCategories.Update(model);
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
