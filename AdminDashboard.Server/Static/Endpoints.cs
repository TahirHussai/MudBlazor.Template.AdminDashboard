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


        public static string JobEndPoint = $"{BaseUrl}api/Job/Post/";
        public static string GetJobEndPoint = $"{BaseUrl}api/Job/";


        public static string CatCreateEndpoint = $"{BaseUrl}api/Category/Post/";
        public static string CatUpdateEndpoint = $"{BaseUrl}api/Category/Update/";
        public static string CatGetByIdEndPoint = $"{BaseUrl}api/Category/";
        public static string CatGetEndPoint = $"{BaseUrl}api/Category/";

        public static string SubCatCreateEndpoint = $"{BaseUrl}api/SubCategory/Post/";
        public static string SubCatUpdateEndpoint = $"{BaseUrl}api/SubCategory/Update/";
        public static string SubCatGetByIdEndPoint = $"{BaseUrl}api/SubCategory/";
        public static string SubCatGetEndPoint = $"{BaseUrl}api/SubCategory/";

    }
}
