using AdminDashboard.Server.Models;
using AdminDashboard.Server.Static;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AdminDashboard.Server.Repository.Interface
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly HttpClient _client;


        public AuthenticationRepository(HttpClient client)
        {
            _client = client;
         
        }

        public async Task<bool> Login(LoginModel user)  
        {
            var obj = new StringContent(
                     JsonConvert.SerializeObject(user),
                     Encoding.UTF8,
                     Application.Json);

            using var httpResponseMessage =
                await _client.PostAsync(Endpoints.LoginEndPoint, obj);

            return httpResponseMessage.IsSuccessStatusCode;
          
        }
       
        public async Task<bool> Register(RegistrationModel user)
        {
            
                var obj = new StringContent(
                      JsonConvert.SerializeObject(user),
                      Encoding.UTF8,
                      Application.Json);

                using var httpResponseMessage =
                    await _client.PostAsync(Endpoints.RegisterEndpoint, obj);

                return httpResponseMessage.IsSuccessStatusCode;

        }

        
    }
}
