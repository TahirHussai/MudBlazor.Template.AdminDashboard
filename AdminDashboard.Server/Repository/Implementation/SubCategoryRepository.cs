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
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly IHttpClientFactory _client;
        public SubCategoryRepository(IHttpClientFactory httpClient)
        {
            _client = httpClient;
        }
        public async Task<ResponseModel> Add(SubCategoryDTO dto)
        {
            var response = await CommonOperations.Save(_client, Endpoints.SubCatCreateEndpoint, dto);
            return response;
        }

        public async Task<List<SubCategoryDTO>> Get()
        {
            List<SubCategoryDTO> list = new List<SubCategoryDTO>();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get
              , Endpoints.SubCatGetEndPoint);

                var client = _client.CreateClient();
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var contnt = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<SubCategoryDTO>>(contnt);
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

        public async Task<SubCategoryDTO> GetById(int id)
        {
            SubCategoryDTO list = new SubCategoryDTO();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get
              , Endpoints.SubCatGetByIdEndPoint + id);

                var client = _client.CreateClient();
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var contnt = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<SubCategoryDTO>(contnt);
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

        public async Task<ResponseModel> Upate(SubCategoryDTO dto)
        {
            var response = await CommonOperations.Update(_client, Endpoints.SubCatUpdateEndpoint, dto);
            return response;
        }
    }
}
