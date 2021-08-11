﻿using MaintenanceManagementSystem.Application.Interfaces;
using MaintenanceManagementSystem.Entity.ModelsDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.API.Controllers
{
    [ApiController]
    //[Route("api/BuildingManager")]
    public class BuildingManagerAPIController : ControllerBase
    {
        private readonly IBuildingManager _buildingManager;
        public BuildingManagerAPIController(IBuildingManager buildingManager)
        {
            _buildingManager = buildingManager;
        }


        [HttpPost]
        [Route("AddComments/{ticket}")]
        public IActionResult AddComments(int id, string comment)
        {
            _buildingManager.AddComments(id, comment);
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
        [Route("ViewBuilding/{id}")]
        public IActionResult ViewBuilding(int managerID)
        {
            var building = _buildingManager.ViewBuilding(managerID);
            return Ok(building);
        }

        //--------------------------------------------------------------------------------------------

       
        //[Route("[action]")]
        // [ActionName("ViewTickets/{id}")]
        [HttpGet]
        [Route("[action]")]
        [Route("api/BuildingManagerAPI/ViewTickets/{id}")]
        public IActionResult  ViewTickets(int managerID)
        {
            var tickets = _buildingManager.ViewTickets(managerID);
            return Ok(tickets);

        }

        
        [HttpGet]
        [Route("ViewTicketsStatus/{id}")]
        public IActionResult ViewTicketsStatus(int managerID)
        {
            var tickets = _buildingManager.ViewTicketsStatus(managerID);
            return Ok(tickets);

        }
    }
}