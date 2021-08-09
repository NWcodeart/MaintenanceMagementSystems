using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.MVC
{
    public class APICaller
    {
        public static HttpClient APIClient { get; set; }
        public static void ApiCaller()
        {

                APIClient = new HttpClient();
                APIClient.BaseAddress = new Uri("https://localhost:44324/api/BuildingManager/");                   
              
        }

       
    }
}
