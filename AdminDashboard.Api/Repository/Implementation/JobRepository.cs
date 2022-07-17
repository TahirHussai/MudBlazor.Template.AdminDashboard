using AdminDashboard.Api.Data.DTO;
using AdminDashboard.Api.Data.Models;
using AdminDashboard.Api.Repository.Interface;
using AdminDashboard.APi.Data;

namespace AdminDashboard.Api.Repository.Implementation
{
    public class JobRepository : IJobRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public JobRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public bool Add(JobDTO user)
        {
            bool status = false;
            try
            {
                _dbContext.Jobs.Add(DTOToEntity(user));
                _dbContext.SaveChanges();
                status = true;

            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        public async Task<IEnumerable<JobDTO>> Get()
        {
            List<JobDTO> listdto = new List<JobDTO>();
            var list = _dbContext.Jobs;
            if (list != null && list.Count() > 0)
            {
                foreach (var item in list)
                {
                    var obj = new JobDTO();
                    obj = EntityToDTO(item);
                    listdto.Add(obj);
                }
            }
            return listdto;
        }

        public Task<JobDTO> GetById()
        {
            throw new NotImplementedException();
        }

        public bool Upate(JobDTO user)
        {
            throw new NotImplementedException();
        }
        private JobDTO EntityToDTO(JOB dto)
        {
            JobDTO model = new JobDTO();
            if (dto != null)
            {
                model.Active = dto.Active;
                model.MUR = dto.MUR;
                model.BR1 = dto.BR1;
                model.BR2 = dto.BR2;
                model.OTR = dto.OTR;
                model.DLR = dto.DLR;
                model.DLR1 = dto.DLR1;
                model.DLR2 = dto.DLR2;
                model.BR1 = dto.BR1;
                model.AddressID = dto.AddressID;
                model.btClientAltRate = dto.btClientAltRate;
                model.dtCreated = dto.dtCreated;
                model.CatID = dto.CatID;
                model.CatID2 = dto.CatID2;
                model.ClientJobTitle = dto.ClientJobTitle;
                model.CreatedByID = dto.CreatedByID;
                model.CRJobTitle = dto.CRJobTitle;
                model.Education = dto.Education;
                model.FirstDayShiftStartTime = dto.FirstDayShiftStartTime;
                model.JobEndDT = dto.JobEndDT;
                model.JobID = dto.JobID;
                model.JobStartDT = dto.JobStartDT;
                model.Miscellaneous = dto.Miscellaneous;
                model.NumOpenings = dto.NumOpenings;
                model.OTBR = dto.OTBR;
                model.OTR = dto.OTR;
                model.RegionId = dto.RegionId;
                model.RemainingOpenings = dto.RemainingOpenings;
                model.Req = dto.Req;
                model.ReqMajor = dto.ReqMajor;
                model.ReqDegree = dto.ReqDegree;
                model.Requirements = dto.Requirements;
                model.Responsibilities = dto.Responsibilities;
                model.SectorID = dto.SectorID;
                model.Shift = dto.Shift;
                model.ShiftStartTimeDT = dto.ShiftStartTimeDT;
                model.ShiftEndTimeDT = dto.ShiftEndTimeDT;
                model.SubRegionID = dto.SubRegionID;
                model.TargetRate = dto.TargetRate;
            }
            return model;
        }
        private JOB DTOToEntity(JobDTO dto)
        {
            JOB model = new JOB();
            if (dto != null)
            {
                model.Active = dto.Active;
                model.MUR = dto.MUR;
                model.BR1 = dto.BR1;
                model.BR2 = dto.BR2;
                model.OTR = dto.OTR;
                model.DLR = dto.DLR;
                model.DLR1 = dto.DLR1;
                model.DLR2 = dto.DLR2;
                model.BR1 = dto.BR1;
                model.AddressID = dto.AddressID;
                model.btClientAltRate = dto.btClientAltRate;
                model.dtCreated = DateTime.Now;
                model.CatID = dto.CatID;
                model.CatID2 = dto.CatID2;
                model.ClientJobTitle = dto.ClientJobTitle;
                model.CreatedByID = dto.CreatedByID;
                model.CRJobTitle = dto.CRJobTitle;
                model.Education = dto.Education;
                model.FirstDayShiftStartTime = dto.FirstDayShiftStartTime;
                model.JobEndDT = dto.JobEndDT;
                model.JobID = dto.JobID;
                model.JobStartDT = dto.JobStartDT;
                model.Miscellaneous = dto.Miscellaneous;
                model.NumOpenings = dto.NumOpenings;
                model.OTBR = dto.OTBR;
                model.OTR = dto.OTR;
                model.RegionId = dto.RegionId;
                model.RemainingOpenings = dto.RemainingOpenings;
                model.Req = dto.Req;
                model.ReqMajor = dto.ReqMajor;
                model.ReqDegree = dto.ReqDegree;
                model.Requirements = dto.Requirements;
                model.Responsibilities = dto.Responsibilities;
                model.SectorID = dto.SectorID;
                model.Shift = dto.Shift;
                model.ShiftStartTimeDT = dto.ShiftStartTimeDT;
                model.ShiftEndTimeDT = dto.ShiftEndTimeDT;
                model.SubRegionID = dto.SubRegionID;
                model.TargetRate = dto.TargetRate;
            }
            return model;
        }
    }
}
