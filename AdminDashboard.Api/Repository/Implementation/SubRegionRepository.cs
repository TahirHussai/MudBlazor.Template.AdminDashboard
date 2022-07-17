using AdminDashboard.Api.Data.DTO;
using AdminDashboard.Api.Data.Models;
using AdminDashboard.Api.Repository.Interface;
using AdminDashboard.APi.Data;

namespace AdminDashboard.Api.Repository.Implementation
{
    public class SubRegionRepository: ISubRegionRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public SubRegionRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ResponseModel Add(SubRegionDTO dto)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                LuSubRegion model = new LuSubRegion();
                model.vchVal = dto.vchVal;
                model.vchDesc = dto.vchDesc;

                _dbContext.LuSubRegions.Add(model);
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

        public async Task<IEnumerable<SubRegionDTO>> Get()
        {

            List<SubRegionDTO> listdto = new List<SubRegionDTO>();

            var list = _dbContext.LuSubRegions.ToList();
            if (list != null && list.Count() > 0)
            {
                foreach (var item in list)
                {
                    var obj = new SubRegionDTO();
                    obj.SubRegionID = item.SubRegionID;
                    obj.vchVal = item.vchVal;
                    obj.vchDesc = item.vchDesc;
                    listdto.Add(obj);
                }
            }

            return listdto;
        }

        public SubRegionDTO GetById(int id)
        {
            SubRegionDTO dto = new SubRegionDTO();
            var model = _dbContext.LuSubRegions.Where(a => a.SubRegionID == id).FirstOrDefault();
            if (model != null)
            {
                dto.SubRegionID = model.SubRegionID;
                dto.vchVal = model.vchVal;
                dto.vchDesc = model.vchDesc;
            }
            return dto;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public ResponseModel Upate(SubRegionDTO dto)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                LuSubRegion model = new LuSubRegion();
                model.SubRegionID = dto.SubRegionID;
                model.vchVal = dto.vchVal;
                model.vchDesc = dto.vchDesc;
                _dbContext.LuSubRegions.Update(model);
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
