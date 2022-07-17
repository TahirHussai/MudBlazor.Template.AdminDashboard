using AdminDashboard.Api.Data.DTO;
using AdminDashboard.Api.Data.Models;
using AdminDashboard.Api.Repository.Interface;
using AdminDashboard.APi.Data;

namespace AdminDashboard.Api.Repository.Implementation
{
    public class SectorRepository : ISectorRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public SectorRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ResponseModel Add(SectorDTO dto)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                LuSector model = new LuSector();
                model.vchVal = dto.vchVal;
                model.vchDesc = dto.vchDesc;

                _dbContext.LuSectors.Add(model);
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

        public async Task<IEnumerable<SectorDTO>> Get()
        {

            List<SectorDTO> listdto = new List<SectorDTO>();

            var list = _dbContext.LuSectors.ToList();
            if (list != null && list.Count() > 0)
            {
                foreach (var item in list)
                {
                    var obj = new SectorDTO();
                    obj.SectorID = item.SectorID;
                    obj.vchVal = item.vchVal;
                    obj.vchDesc = item.vchDesc;
                    listdto.Add(obj);
                }
            }

            return listdto;
        }

        public SectorDTO GetById(int id)
        {
            SectorDTO dto = new SectorDTO();
            var model = _dbContext.LuSectors.Where(a => a.SectorID == id).FirstOrDefault();
            if (model != null)
            {
                dto.SectorID = model.SectorID;
                dto.vchVal = model.vchVal;
                dto.vchDesc = model.vchDesc;
            }
            return dto;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public ResponseModel Upate(SectorDTO dto)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                LuSector model = new LuSector();
                model.SectorID = dto.SectorID;
                model.vchVal = dto.vchVal;
                model.vchDesc = dto.vchDesc;
                _dbContext.LuSectors.Update(model);
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
