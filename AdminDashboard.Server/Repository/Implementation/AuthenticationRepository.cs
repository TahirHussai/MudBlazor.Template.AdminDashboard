using AdminDashboard.Server.Models;
using AdminDashboard.Server.Providers;
using AdminDashboard.Server.Static;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AdminDashboard.Server.Repository.Interface
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly IHttpClientFactory _client;

        private readonly ILocalStorageService _localStorage;
        private readonly ApiAuthenticationStateProvider _apiAuthenticationStateProvider;
        public AuthenticationRepository(IHttpClientFactory client,
           ILocalStorageService localStorage, ApiAuthenticationStateProvider apiAuthenticationStateProvider
            )
        {
            _client = client;
            _localStorage = localStorage;
            _apiAuthenticationStateProvider = apiAuthenticationStateProvider;
        }

        public async Task<bool> Login(LoginModel user)
        {
            var request = new HttpRequestMessage(HttpMethod.Post
               , Endpoints.LoginEndPoint);
            request.Content = new StringContent(JsonConvert.SerializeObject(user)
                , Encoding.UTF8, "application/json");

            var client = _client.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                return false;
            }

            var content = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<ResponseModel>(content);

            //Store Token
            if (token.IsSuccess)
            {

            
            await _localStorage.SetItemAsync("authToken", token.Token);
            await _localStorage.SetItemAsync("LoginEmail", user.EmailAddress);
            await _localStorage.SetItemAsync("LoginUserImage", token.ProfilePicture);
            await _localStorage.SetItemAsync("LoginUserName", token.UserName);

            //Change auth state of app
            await ((ApiAuthenticationStateProvider)_apiAuthenticationStateProvider).LoggedIn(user.EmailAddress);
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("bearer", token.Token);
            return true;
            }
            return false;
        }

        public async Task<bool> Register(RegistrationModel user)
        {

            var request = new HttpRequestMessage(HttpMethod.Post
                  , Endpoints.RegisterEndpoint)
            {
                Content = new StringContent(JsonConvert.SerializeObject(user)
                  , Encoding.UTF8, "application/json")
            };

            var client = _client.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            return response.IsSuccessStatusCode;

        }
        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("authToken");
            await _localStorage.RemoveItemAsync("LoginEmail");
            await _localStorage.RemoveItemAsync("LoginUserImage");
            await _localStorage.RemoveItemAsync("LoginUserName");
            ((ApiAuthenticationStateProvider)_apiAuthenticationStateProvider)
                .LoggedOut();
        }

        public async Task<IEnumerable<UserModel>> Get()
        {
            List<UserModel> list = new List<UserModel>();
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get
              , Endpoints.GetUerEndPoint);

                var client = _client.CreateClient();
                HttpResponseMessage response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var contnt = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<IList<UserModel>>(contnt);
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
    }
}
