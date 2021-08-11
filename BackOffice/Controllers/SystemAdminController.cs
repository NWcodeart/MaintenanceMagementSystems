using MaintenanceManagementSystem.BackOffice.Helper;
using MaintenanceManagementSystem.Entity.ModelsDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.BackOffice.Controllers
{
    public class SystemAdminController : Controller
    {
        HelperApi HttpHelper = new HelperApi();
        public async Task<IActionResult> IndexAsync()
        {
            List<BuildingsTable> buildingsTable = new List<BuildingsTable>();
            HttpClient Client = HttpHelper.Initial();
            HttpResponseMessage res = await Client.GetAsync("api/GetBuildingTables");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                buildingsTable = JsonConvert.DeserializeObject<List<BuildingsTable>>(result);
            }
            return View(buildingsTable);
        }
    }
}
