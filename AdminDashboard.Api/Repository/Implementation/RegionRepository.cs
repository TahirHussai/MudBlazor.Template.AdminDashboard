using AdminDashboard.Api.Data.DTO;
using AdminDashboard.Api.Data.Models;
using AdminDashboard.Api.Repository.Interface;
using AdminDashboard.APi.Data;

namespace AdminDashboard.Api.Repository.Implementation
{
    public class RegionRepository: IRegionRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public RegionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ResponseModel Add(RegionDTO dto)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                LuRegion model = new LuRegion();
                model.Abv = dto.Abv;
                model.Desc = dto.Desc;

                _dbContext.LuRegions.Add(model);
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

        public async Task<IEnumerable<RegionDTO>> Get()
        {

            List<RegionDTO> listdto = new List<RegionDTO>();

            var list = _dbContext.LuRegions.ToList();
            if (list != null && list.Count() > 0)
            {
                foreach (var item in list)
                {
                    var obj = new RegionDTO();
                    obj.RegionID = item.RegionID;
                    obj.Abv = item.Abv;
                    obj.Desc = item.Desc;
                    listdto.Add(obj);
                }
            }

            return listdto;
        }

        public RegionDTO GetById(int id)
        {
            RegionDTO dto = new RegionDTO();
            var model = _dbContext.LuRegions.Where(a => a.RegionID == id).FirstOrDefault();
            if (model != null)
            {
                dto.RegionID = model.RegionID;
                dto.Abv = model.Abv;
                dto.Desc = model.Desc;
            }
            return dto;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public ResponseModel Upate(RegionDTO dto)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                LuRegion model = new LuRegion();
                model.RegionID = dto.RegionID;
                model.Abv = dto.Abv;
                model.Desc = dto.Desc;
                _dbContext.LuRegions.Update(model);
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
