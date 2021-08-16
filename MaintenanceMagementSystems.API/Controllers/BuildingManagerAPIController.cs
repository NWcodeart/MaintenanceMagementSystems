using MaintenanceMagementSystems.API.Filters;
using MaintenanceManagementSystem.Application.Interfaces;
using MaintenanceManagementSystem.Entity.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.API.Controllers
{
    [ServiceFilter(typeof(AuthorizeFilter))]
    [ServiceFilter(typeof(ActionFilter))]
    [ServiceFilter(typeof(ExceptionFilter))]
    [Authorize(Roles = "BuildingManager")]
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingManagerAPIController : ControllerBase
    {
        private readonly IBuildingManager _buildingManager;
        public BuildingManagerAPIController(IBuildingManager buildingManager)
        {
            _buildingManager = buildingManager;
        }


        [HttpPost]
        [Route("[action]")]
        [ActionName("AddComments/{comment}")]
        public IActionResult AddComments( string comment)
        {
            _buildingManager.AddComments( comment);
            return Ok();
        }

        //--------------------------------------------------------------------------------------------

        [HttpPost]
        [Route("EditBuilding/{id}/{building}")]
        public IActionResult EditBuilding(int buildingID, BuildingDto Updatedbuilding)
        {
             _buildingManager.EditBuilding(buildingID, Updatedbuilding);
            return Ok();

        }

        //--------------------------------------------------------------------------------------------


        [HttpGet]
        [Route("[action]")]
        [ActionName("ViewBuilding")]
        public IActionResult ViewBuilding()
        {
            var building = _buildingManager.ViewBuilding();
            return Ok(building);
        }

        //--------------------------------------------------------------------------------------------

       
        //[Route("[action]")]
        // [ActionName("ViewTickets/{id}")]
        [HttpGet]
        [Route("[action]")]
        [Route("api/BuildingManagerAPI/ViewTickets/{id}")]
        public IActionResult  ViewTickets()
        {
            var tickets = _buildingManager.ViewTickets();
            return Ok(tickets);

        }

        
        [HttpGet]
        [Route("ViewTicketsStatus/{id}")]
        public IActionResult ViewTicketsStatus()
        {
            var tickets = _buildingManager.ViewTicketsStatus();
            return Ok(tickets);

        }
    }
}
