using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard.Server.Static
{
    public static class Endpoints
    {
        public static string BaseUrl = "https://localhost:7081/";
        
        public static string RegisterEndpoint = $"{BaseUrl}api/Account/register/";
        public static string LoginEndPoint = $"{BaseUrl}api/Account/login/";
        public static string GetUerEndPoint = $"{BaseUrl}api/Account/";
    }
}
