using MaintenanceManagementSystem.API.Controllers;
using MaintenanceManagementSystem.Application.Interfaces;
using MaintenanceManagementSystem.Database.Models;
using MaintenanceManagementSystem.Entity.ModelsDto;
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
        private readonly IBuildingManager _buildingManager;

        public BuildingManagerController(IBuildingManager buildingManager)
        {
            _buildingManager = buildingManager;
        }
        public ActionResult AddComments()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> PostComments(int id, string comment)
        {
            
                _buildingManager.AddComments(id, comment);
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
            var tickets = _buildingManager.ViewTickets(managerID);
            return Json(tickets, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }


        //--------------------------------------------------------------------------------------------------------------------------


        public ActionResult ViewBuilding()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> GetBuilding(int managerID)
        {
            var building = _buildingManager.ViewBuilding(managerID);
            return Json(building, System.Web.Mvc.JsonRequestBehavior.AllowGet);
        }


        //--------------------------------------------------------------------------------------------------------------------------
    }
}
