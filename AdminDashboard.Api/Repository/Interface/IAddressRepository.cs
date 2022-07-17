using AdminDashboard.Api.Data.DTO;
using AdminDashboard.Api.Data.Models;

namespace AdminDashboard.Api.Repository.Interface
{
    public interface IAddressRepository
    {
        public Task<IEnumerable<AddressDTO>> Get();
        public AddressDTO GetById(int id);
        public ResponseModel Add(AddressDTO dto);
        public ResponseModel Upate(AddressDTO dto);
        void Save();
    }
}
