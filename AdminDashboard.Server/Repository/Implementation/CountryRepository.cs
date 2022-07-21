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
    public class CountryRepository : ICountryRepository
    {
        private readonly IHttpClientFactory _client;
        public CountryRepository(IHttpClientFactory httpClient)
        {
            _client = httpClient;
        }
        public async Task<ResponseModel> Add(CountryDTO dto)
        {
            var response = await CommonOperations.Save(_client, Endpoints.CountryCreateEndpoint, dto);
            return response;
        }

        public async Task<List<CountryDTO>> Get()
        {
            List<CountryDTO> list = new List<CountryDTO>();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get
              , Endpoints.CountryGetEndPoint);

                var client = _client.CreateClient();
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var contnt = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<CountryDTO>>(contnt);
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

        public async Task<CountryDTO> GetById(int id)
        {
            CountryDTO list = new CountryDTO();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get
              , Endpoints.CountryGetByIdEndPoint + id);

                var client = _client.CreateClient();
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var contnt = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<CountryDTO>(contnt);
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

        public async Task<ResponseModel> Upate(CountryDTO dto)
        {
            var response = await CommonOperations.Update(_client, Endpoints.CountryUpdateEndpoint, dto);
            return response;
        }
    }
}
