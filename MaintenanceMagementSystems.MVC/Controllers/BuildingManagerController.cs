using MaintenanceManagementSystem.Database.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
//using System.Web.Mvc;

namespace MaintenanceManagementSystem.MVC.Controllers
{
    public class BuildingManagerController : Controller
    {
        public ActionResult AddComments()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> PostComments(Ticket ticket)
        {
            string response = "";
       
            using (HttpClient client = new HttpClient())
            {
                Ticket ticketObject = new Ticket();
                ticketObject.BuildingManagerComment = ticket.BuildingManagerComment;
                client.BaseAddress = new Uri("https://localhost:44324/api/BuildingManager/");
                var httpResponse = await client.PutAsJsonAsync($"AddComments/{ticketObject}", ticket.BuildingManagerComment);
                if (httpResponse.IsSuccessStatusCode)
                {
                    response = await httpResponse.Content.ReadAsStringAsync();
                }
            }
            return View();
        }


        //--------------------------------------------------------------------------------------------------------------------------

        public ActionResult ViewTickets()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> GetTickets(int managerID)
        {
            List<Ticket> ticketList = new List<Ticket>();
            using (HttpClient client = new HttpClient())
            {
                var httpResponse = await client.GetAsync($"https://localhost:44324/api/BuildingManager/ViewTickets/{managerID}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    ticketList = await httpResponse.Content.ReadFromJsonAsync<List<Ticket>>();
                }
            }
            //return View();
            return Json(ticketList, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }


        //--------------------------------------------------------------------------------------------------------------------------


        public ActionResult ViewBuilding()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> GetBuilding(int managerID)
        {
            APICaller.ApiCaller();
            Building building = new Building();
            using (APICaller.APIClient)
            {
                var httpResponse = await APICaller.APIClient.GetAsync($"ViewBuilding/{managerID}");
                if (httpResponse.IsSuccessStatusCode)
                {
                    building = await httpResponse.Content.ReadFromJsonAsync<Building>();
                }
            }
            //return View();
            return Json(building, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }


        //--------------------------------------------------------------------------------------------------------------------------
    }
}
