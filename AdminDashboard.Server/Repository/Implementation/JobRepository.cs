
using AdminDashboard.Server.Repository.Interface;
using AdminDashboard.Server.Static;
using Blazored.LocalStorage;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboard.Server.Repository.Implementation
{
    public class JobRepository : IJobRepository
    {
        private readonly IHttpClientFactory _client;
        public JobRepository(IHttpClientFactory httpClient)
        {
            _client=httpClient;
        }
        public async Task<bool> Add(JobDTO dto)
        {
            bool IsSuccess = false;
            dto.dtCreated = DateTime.Now;
            dto.FirstDayShiftStartTime = "";
            var request = new HttpRequestMessage(HttpMethod.Post
               , Endpoints.JobEndPoint);
            request.Content = new StringContent(JsonConvert.SerializeObject(dto)
                , Encoding.UTF8, "application/json");

            var client = _client.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                IsSuccess = true;
            }
            return IsSuccess;
        }

        public async Task<IEnumerable<JobDTO>> Get()
        {
            List<JobDTO> list = new List<JobDTO>();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get
              , Endpoints.GetJobEndPoint);

                var client = _client.CreateClient();
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var contnt = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IList<JobDTO>>(contnt);
                }
                else
                {
                    return list;
                }
            }
            catch (Exception ex)
            {
                return list;

            }
        }

        public Task<JobDTO> GetById()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Upate(JobDTO user)
        {
            throw new NotImplementedException();
        }

        //public async Task<bool> Upate(JobDTO user)
        //{
        //    throw new NotImplementedException();
        //}
        //private JobDTO EntityToDTO(JOB dto)
        //{
        //    JobDTO model = new JobDTO();
        //    if (dto != null)
        //    {
        //        model.Active = dto.Active;
        //        model.MUR = dto.MUR;
        //        model.BR1 = dto.BR1;
        //        model.BR2 = dto.BR2;
        //        model.OTR = dto.OTR;
        //        model.DLR = dto.DLR;
        //        model.DLR1 = dto.DLR1;
        //        model.DLR2 = dto.DLR2;
        //        model.BR1 = dto.BR1;
        //        model.AddressID = dto.AddressID;
        //        model.btClientAltRate = dto.btClientAltRate;
        //        model.dtCreated = dto.dtCreated;
        //        model.CatID = dto.CatID;
        //        model.CatID2 = dto.CatID2;
        //        model.ClientJobTitle = dto.ClientJobTitle;
        //        model.CreatedByID = dto.CreatedByID;
        //        model.CRJobTitle = dto.CRJobTitle;
        //        model.Education = dto.Education;
        //        model.FirstDayShiftStartTime = dto.FirstDayShiftStartTime;
        //        model.JobEndDT = dto.JobEndDT;
        //        model.JobID = dto.JobID;
        //        model.JobStartDT = dto.JobStartDT;
        //        model.Miscellaneous = dto.Miscellaneous;
        //        model.NumOpenings = dto.NumOpenings;
        //        model.OTBR = dto.OTBR;
        //        model.OTR = dto.OTR;
        //        model.RegionId = dto.RegionId;
        //        model.RemainingOpenings = dto.RemainingOpenings;
        //        model.Req = dto.Req;
        //        model.ReqMajor = dto.ReqMajor;
        //        model.ReqDegree = dto.ReqDegree;
        //        model.Requirements = dto.Requirements;
        //        model.Responsibilities = dto.Responsibilities;
        //        model.SectorID = dto.SectorID;
        //        model.Shift = dto.Shift;
        //        model.ShiftStartTimeDT = dto.ShiftStartTimeDT;
        //        model.ShiftEndTimeDT = dto.ShiftEndTimeDT;
        //        model.SubRegionID = dto.SubRegionID;
        //        model.TargetRate = dto.TargetRate;
        //    }
        //    return model;
        //}
        //private JOB DTOToEntity(JobDTO dto)
        //{
        //    JOB model = new JOB();
        //    if (dto != null)
        //    {
        //        model.Active = dto.Active;
        //        model.MUR = dto.MUR;
        //        model.BR1 = dto.BR1;
        //        model.BR2 = dto.BR2;
        //        model.OTR = dto.OTR;
        //        model.DLR = dto.DLR;
        //        model.DLR1 = dto.DLR1;
        //        model.DLR2 = dto.DLR2;
        //        model.BR1 = dto.BR1;
        //        model.AddressID = dto.AddressID;
        //        model.btClientAltRate = dto.btClientAltRate;
        //        model.dtCreated = DateTime.Now;
        //        model.CatID = dto.CatID;
        //        model.CatID2 = dto.CatID2;
        //        model.ClientJobTitle = dto.ClientJobTitle;
        //        model.CreatedByID = dto.CreatedByID;
        //        model.CRJobTitle = dto.CRJobTitle;
        //        model.Education = dto.Education;
        //        model.FirstDayShiftStartTime = dto.FirstDayShiftStartTime;
        //        model.JobEndDT = dto.JobEndDT;
        //        model.JobID = dto.JobID;
        //        model.JobStartDT = dto.JobStartDT;
        //        model.Miscellaneous = dto.Miscellaneous;
        //        model.NumOpenings = dto.NumOpenings;
        //        model.OTBR = dto.OTBR;
        //        model.OTR = dto.OTR;
        //        model.RegionId = dto.RegionId;
        //        model.RemainingOpenings = dto.RemainingOpenings;
        //        model.Req = dto.Req;
        //        model.ReqMajor = dto.ReqMajor;
        //        model.ReqDegree = dto.ReqDegree;
        //        model.Requirements = dto.Requirements;
        //        model.Responsibilities = dto.Responsibilities;
        //        model.SectorID = dto.SectorID;
        //        model.Shift = dto.Shift;
        //        model.ShiftStartTimeDT = dto.ShiftStartTimeDT;
        //        model.ShiftEndTimeDT = dto.ShiftEndTimeDT;
        //        model.SubRegionID = dto.SubRegionID;
        //        model.TargetRate = dto.TargetRate;
        //    }
        //    return model;
        //}
    }
}
