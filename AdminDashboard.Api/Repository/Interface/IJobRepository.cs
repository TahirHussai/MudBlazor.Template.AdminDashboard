using AdminDashboard.Api.Data.DTO;

namespace AdminDashboard.Api.Repository.Interface
{
    public interface IJobRepository
    {
        public Task<IEnumerable<JobDTO>> Get();
        public Task<JobDTO> GetById();
        public bool Add(JobDTO user);
        public bool Upate(JobDTO user);
    }
}
