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
    public class AddressRepository: IAddressRepository
    {
        private readonly IHttpClientFactory _client;
        public AddressRepository(IHttpClientFactory httpClient)
        {
            _client = httpClient;
        }
        public async Task<ResponseModel> Add(AddressDTO dto)
        {
            var response = await CommonOperations.Save(_client, Endpoints.AddressCreateEndpoint, dto);
            return response;
        }

        public async Task<List<AddressDTO>> Get()
        {
            List<AddressDTO> list = new List<AddressDTO>();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get
              , Endpoints.AddressGetEndPoint);

                var client = _client.CreateClient();
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var contnt = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<AddressDTO>>(contnt);
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

        public async Task<AddressDTO> GetById(int id)
        {
            AddressDTO list = new AddressDTO();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get
              , Endpoints.AddressGetByIdEndPoint + id);

                var client = _client.CreateClient();
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var contnt = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<AddressDTO>(contnt);
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

        public async Task<ResponseModel> Upate(AddressDTO dto)
        {
            var response = await CommonOperations.Update(_client, Endpoints.AddressUpdateEndpoint, dto);
            return response;
        }
    }
}
