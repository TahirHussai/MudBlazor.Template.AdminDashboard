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


        public static string SectorCreateEndpoint = $"{BaseUrl}api/Sector/Post/";
        public static string SectorUpdateEndpoint = $"{BaseUrl}api/Sector/Update/";
        public static string SectorGetByIdEndPoint = $"{BaseUrl}api/Sector/";
        public static string SectorGetEndPoint = $"{BaseUrl}api/Sector/";


        public static string RegionCreateEndpoint = $"{BaseUrl}api/Region/Post/";
        public static string RegionUpdateEndpoint = $"{BaseUrl}api/Region/Update/";
        public static string RegionGetByIdEndPoint = $"{BaseUrl}api/Region/";
        public static string RegionGetEndPoint = $"{BaseUrl}api/Region/";


        public static string SubRegionCreateEndpoint = $"{BaseUrl}api/SubRegion/Post/";
        public static string SubRegionUpdateEndpoint = $"{BaseUrl}api/SubRegion/Update/";
        public static string SubRegionGetByIdEndPoint = $"{BaseUrl}api/SubRegion/";
        public static string SubRegionGetEndPoint = $"{BaseUrl}api/SubRegion/";

        public static string AddressCreateEndpoint = $"{BaseUrl}api/Address/Post/";
        public static string AddressUpdateEndpoint = $"{BaseUrl}api/Address/Update/";
        public static string AddressGetByIdEndPoint = $"{BaseUrl}api/Address/";
        public static string AddressGetEndPoint = $"{BaseUrl}api/Address/";


        public static string CountryGetByIdEndPoint = $"{BaseUrl}api/Country/";
        public static string CountryGetEndPoint = $"{BaseUrl}api/Country/";
        public static string CountryCreateEndpoint = $"{BaseUrl}api/Country/Post/";
        public static string CountryUpdateEndpoint = $"{BaseUrl}api/Country/Update/";
    }
}
