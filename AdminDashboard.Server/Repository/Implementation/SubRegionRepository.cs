using AdminDashboard.Server.DTO;
using AdminDashboard.Server.Models;
using AdminDashboard.Server.Repository.Interface;
using AdminDashboard.Server.Static;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdminDashboard.Server.Repository.Implementation
{
    public class SubRegionRepository : ISubRegionRepository
    {
        private readonly IHttpClientFactory _client;
        public SubRegionRepository(IHttpClientFactory httpClient)
        {
            _client = httpClient;
        }
        public async Task<ResponseModel> Add(SubRegionDTO dto)
        {
            var response = await CommonOperations.Save(_client, Endpoints.SubRegionCreateEndpoint, dto);
            return response;
        }
        public async Task<List<SubRegionDTO>> Get()
        {
            List<SubRegionDTO> list = new List<SubRegionDTO>();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get
              , Endpoints.SubRegionGetEndPoint);

                var client = _client.CreateClient();
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var contnt = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<SubRegionDTO>>(contnt);
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

        public async Task<SubRegionDTO> GetById(int id)
        {
            SubRegionDTO list = new SubRegionDTO();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get
              , Endpoints.SubRegionGetByIdEndPoint + id);

                var client = _client.CreateClient();
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var contnt = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<SubRegionDTO>(contnt);
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
        public async Task<ResponseModel> Upate(SubRegionDTO dto)
        {
            var response = await CommonOperations.Update(_client, Endpoints.SubRegionUpdateEndpoint, dto);
            return response;
        }
    }
}
