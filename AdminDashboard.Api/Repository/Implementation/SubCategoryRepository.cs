using AdminDashboard.Api.Data.DTO;
using AdminDashboard.Api.Data.Models;
using AdminDashboard.Api.Repository.Interface;
using AdminDashboard.APi.Data;

namespace AdminDashboard.Api.Repository.Implementation
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICategoryRepository _categoryRepository;
        public SubCategoryRepository(ICategoryRepository categoryRepository, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _categoryRepository = categoryRepository;
        }
        public ResponseModel Add(SubCategoryDTO dto)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                var exists = _categoryRepository.GetById(dto.CategoryRID);
                if (exists == null)
                {
                    response.IsSuccess = false;
                    response.ResponseMessage = "Category Id not exists!";
                    return response;
                }
                LuSubCategory model = new LuSubCategory();
                model.Abv = dto.Abv;
                model.Desc = dto.Desc;
                model.CategoryRID = dto.CategoryRID;
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
                    obj.CategoryRID = item.CategoryRID;
                    obj.SubCatID = item.SubCatID;
                    obj.CategoryTitle= _categoryRepository.GetById(item.CategoryRID).vchDesc;
                    obj.Abv = item.Abv;
                    obj.Desc = item.Desc;
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
                dto.CategoryRID = model.CategoryRID;
                dto.SubCatID = model.SubCatID;
                dto.Abv = model.Abv;
                dto.Desc = model.Desc;
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
                var exists = _categoryRepository.GetById(dto.CategoryRID);
                if (exists == null)
                {
                    response.IsSuccess = false;
                    response.ResponseMessage = "Category Id not exists!";
                    return response;
                }
                LuSubCategory model = new LuSubCategory();
                model.CategoryRID = dto.CategoryRID;
                model.SubCatID = dto.SubCatID;
                model.Abv = dto.Abv;
                model.Desc = dto.Desc;
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
