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
    public class SectorRepository : ISectorRepository
    {
        private readonly IHttpClientFactory _client;
        public SectorRepository(IHttpClientFactory httpClient)
        {
            _client = httpClient;
        }
        public async Task<ResponseModel> Add(SectorDTO dto)
        {
            var response = await CommonOperations.Save(_client, Endpoints.SectorCreateEndpoint, dto);
            return response;
        }

        public async Task<List<SectorDTO>> Get()
        {
            List<SectorDTO> list = new List<SectorDTO>();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get
              , Endpoints.SectorGetEndPoint);

                var client = _client.CreateClient();
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var contnt = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<SectorDTO>>(contnt);
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

        public async Task<SectorDTO> GetById(int id)
        {
            SectorDTO list = new SectorDTO();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get
              , Endpoints.SectorGetByIdEndPoint + id);

                var client = _client.CreateClient();
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var contnt = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<SectorDTO>(contnt);
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

        public async Task<ResponseModel> Upate(SectorDTO dto)
        {
            var response = await CommonOperations.Update(_client, Endpoints.SectorUpdateEndpoint, dto);
            return response;
        }
    }
}
