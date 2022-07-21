using AdminDashboard.Api.Data.DTO;
using AdminDashboard.Api.Data.Models;
using AdminDashboard.Api.Repository.Interface;
using AdminDashboard.APi.Data;

namespace AdminDashboard.Api.Repository.Implementation
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ICountryRepository  _countryRepository;
        private readonly IRegionRepository  _regionRepository;
        public AddressRepository(IRegionRepository regionRepository, ICountryRepository countryRepository, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _countryRepository= countryRepository;
            _regionRepository = regionRepository;
        }
        public ResponseModel Add(AddressDTO dto)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Address model = new Address();
                model.Address1 = dto.Address1;
                model.Address2 = dto.Address2;
                model.CreatedByID = dto.CreatedByID;
                model.CreateDate = DateTime.Now;
                model.City = dto.City;
                model.CountryID = dto.CountryID;
                
                model.PostalCode = dto.PostalCode;
                model.StateID = dto.StateID;

                _dbContext.Addresses.Add(model);
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

        public async Task<IEnumerable<AddressDTO>> Get()
        {

            List<AddressDTO> listdto = new List<AddressDTO>();

            var list = _dbContext.Addresses.ToList();
            if (list != null && list.Count() > 0)
            {
                foreach (var item in list)
                {
                    var obj = new AddressDTO();
                    obj.Address1 = item.Address1;
                    obj.Address2 = item.Address2;
                    obj.CreatedByID = item.CreatedByID;
                    obj.CreateDate = item.CreateDate;
                    obj.City = item.City;
                    obj.CountryID = item.CountryID;
                    obj.CountryName = _countryRepository.GetById(item.CountryID).CountryName;
                    obj.StateName = _regionRepository.GetById(item.StateID).Desc;
                    obj.PostalCode = item.PostalCode;
                    obj.StateID = item.StateID;
                    obj.AddressID = item.AddressID;
                    listdto.Add(obj);
                }
            }

            return listdto;
        }

        public AddressDTO GetById(int id)
        {
            AddressDTO dto = new AddressDTO();
            var model = _dbContext.Addresses.Where(a => a.AddressID == id).FirstOrDefault();
            if (model != null)
            {
                dto.Address1 = model.Address1;
                dto.Address2 = model.Address2;
                dto.CreatedByID = model.CreatedByID;
                dto.CreateDate = model.CreateDate;
                dto.City = model.City;
                dto.CountryID = model.CountryID;
                dto.PostalCode = model.PostalCode;
                dto.StateID = model.StateID;
                dto.AddressID = model.AddressID;
            }
            return dto;
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public ResponseModel Upate(AddressDTO dto)
        {
            ResponseModel response = new ResponseModel();
            try
            {
                Address model = new Address();
                model.AddressID = dto.AddressID;
                model.Address1 = dto.Address1;
                model.Address2 = dto.Address2;
                model.CreatedByID = dto.CreatedByID;
                model.CreateDate = dto.CreateDate;
                model.City = dto.City;
                model.CountryID = dto.CountryID;
                model.PostalCode = dto.PostalCode;
                model.StateID = dto.StateID;
                _dbContext.Addresses.Update(model);
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
