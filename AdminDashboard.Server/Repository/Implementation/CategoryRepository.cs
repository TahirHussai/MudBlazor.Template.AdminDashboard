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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IHttpClientFactory _client;
        public CategoryRepository(IHttpClientFactory httpClient)
        {
            _client = httpClient;
        }
        public async Task<ResponseModel> Add(CategoryDTO dto)
        {
            var response = await CommonOperations.Save(_client, Endpoints.CatCreateEndpoint, dto);
            return response;
        }

        public async Task<List<CategoryDTO>> Get()
        {
            List<CategoryDTO> list = new List<CategoryDTO>();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get
              , Endpoints.CatGetEndPoint);

                var client = _client.CreateClient();
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var contnt = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<CategoryDTO>>(contnt);
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

        public async Task<CategoryDTO> GetById(int id)
        {
            CategoryDTO list = new CategoryDTO();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get
              , Endpoints.CatGetByIdEndPoint  + id);

                var client = _client.CreateClient();
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var contnt = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<CategoryDTO>(contnt);
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

        public async Task<ResponseModel> Upate(CategoryDTO dto)
        {
            var response = await CommonOperations.Update(_client, Endpoints.CatUpdateEndpoint, dto);
            return response;
        }

    }
}
