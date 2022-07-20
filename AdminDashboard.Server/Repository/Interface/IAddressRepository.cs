using AdminDashboard.Server.DTO;
using AdminDashboard.Server.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminDashboard.Server.Repository.Interface
{
    public interface IAddressRepository
    {
        public Task<List<AddressDTO>> Get();
        public Task<AddressDTO> GetById(int id);
        public Task<ResponseModel> Add(AddressDTO dto);
        public Task<ResponseModel> Upate(AddressDTO dto);
    }
}
