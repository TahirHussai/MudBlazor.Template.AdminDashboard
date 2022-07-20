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
    public class RegionRepository: IRegionRepository
    {
        private readonly IHttpClientFactory _client;
        public RegionRepository(IHttpClientFactory httpClient)
        {
            _client = httpClient;
        }
        public async Task<ResponseModel> Add(RegionDTO dto)
        {
            var response = await CommonOperations.Save(_client, Endpoints.RegionCreateEndpoint, dto);
            return response;
        }
        public async Task<List<RegionDTO>> Get()
        {
            List<RegionDTO> list = new List<RegionDTO>();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get
              , Endpoints.RegionGetEndPoint);

                var client = _client.CreateClient();
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var contnt = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<RegionDTO>>(contnt);
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

        public async Task<RegionDTO> GetById(int id)
        {
            RegionDTO list = new RegionDTO();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get
              , Endpoints.RegionGetByIdEndPoint + id);

                var client = _client.CreateClient();
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var contnt = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<RegionDTO>(contnt);
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
        public async Task<ResponseModel> Upate(RegionDTO dto)
        {
            var response = await CommonOperations.Update(_client, Endpoints.RegionUpdateEndpoint, dto);
            return response;
        }
    }
}
