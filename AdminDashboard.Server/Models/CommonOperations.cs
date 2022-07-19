using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AdminDashboard.Server.Models
{
    public static class CommonOperations
    {
        public static async Task<ResponseModel>  Save(IHttpClientFactory httpClient,string Endpoint,object data)
        {
            ResponseModel model = new ResponseModel();

            var request = new HttpRequestMessage(HttpMethod.Post
               , Endpoint);
            request.Content = new StringContent(JsonConvert.SerializeObject(data)
                , Encoding.UTF8, "application/json");

            var client = httpClient.CreateClient();
            HttpResponseMessage response = await  client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                model.IsSuccess = false;
                return model;
            }
            var content = await response.Content.ReadAsStringAsync();
            model =  JsonConvert.DeserializeObject<ResponseModel>(content);
            return model;
        }
        public static async Task<ResponseModel> Update(IHttpClientFactory httpClient, string Endpoint, object data)
        {
            ResponseModel model = new ResponseModel();

            var request = new HttpRequestMessage(HttpMethod.Put
               , Endpoint);
            request.Content = new StringContent(JsonConvert.SerializeObject(data)
                , Encoding.UTF8, "application/json");

            var client = httpClient.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                model.IsSuccess = false;
                return model;
            }
            var content = await response.Content.ReadAsStringAsync();
            model = JsonConvert.DeserializeObject<ResponseModel>(content);
            return model;
        }

    }
}
