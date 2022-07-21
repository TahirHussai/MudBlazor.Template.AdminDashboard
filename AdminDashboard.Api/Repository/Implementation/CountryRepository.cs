using AdminDashboard.Api.Data.DTO;
using AdminDashboard.Api.Data.Models;
using AdminDashboard.Api.Repository.Interface;
using AdminDashboard.APi.Data;

namespace AdminDashboard.Api.Repository.Implementation
{
    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CountryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public ResponseModel Add(CountryDTO dto)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Countires model = new Countires();
                model.CountryName = dto.CountryName;
                model.Abv = dto.Abv;

                _dbContext.Countires.Add(model);
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

        public async Task<IEnumerable<CountryDTO>> Get()
        {
            List<CountryDTO> listdto = new List<CountryDTO>();



            var list = _dbContext.Countires.ToList();
            if (list != null && list.Count() > 0)
            {
                foreach (var item in list)
                {
                    var obj = new CountryDTO();
                    obj.ID = item.ID;
                    obj.CountryName = item.CountryName;
                    obj.Abv = item.Abv;
                    listdto.Add(obj);
                }
            }

            return listdto;
        }

        public CountryDTO GetById(int id)
        {
            CountryDTO dto = new CountryDTO();
            var model = _dbContext.Countires.Where(a => a.ID == id).FirstOrDefault();
            if (model != null)
            {
                dto.ID = model.ID;
                dto.CountryName = model.CountryName;
                dto.Abv = model.Abv;
            }
            return dto;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public ResponseModel Upate(CountryDTO dto)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Countires model = new Countires();
                model.ID = dto.ID;
                model.CountryName = dto.CountryName;
                model.Abv = dto.Abv;
                _dbContext.Countires.Update(model);
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
