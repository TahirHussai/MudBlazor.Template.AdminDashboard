using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdminDashboard.Server.Repository.Interface
{
    public interface IJobRepository
    {
        public Task<IEnumerable<JobDTO>> Get();
        public Task<JobDTO> GetById();
        public Task<bool> Add(JobDTO user);
        public Task<bool> Upate(JobDTO user);
    }
}
