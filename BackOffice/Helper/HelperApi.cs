using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.BackOffice.Helper
{
    public class HelperApi
    {
        public HttpClient Initial()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:16982");
            return client;
        }
    }
}
