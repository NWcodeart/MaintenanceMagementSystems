using MaintenanceMagementSystems.API.Filters;
using MaintenanceManagementSystem.Application.Interfaces;
using MaintenanceManagementSystem.Database.Lookup;
using MaintenanceManagementSystem.Database.Models;
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
    [Authorize(Roles = "MaintenanceManager")]
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceManagerController : ControllerBase
    {
        private readonly IMaintenanceManager _maintenanceManager;
        public MaintenanceManagerController(IMaintenanceManager maintenanceManager)
        {
            _maintenanceManager = maintenanceManager;
        }


        [HttpPost]
        [Route("GetTicket/{id}")]
        public IActionResult GetTicket(int TicketId)
        {
            Ticket ticket = _maintenanceManager.GetTicket(TicketId);
            return Ok(ticket);
        }

        //--------------------------------------------------------------------------------------------

        [HttpPost]
        [Route("ViewTickets")]
        public IActionResult ViewTickets()
        {
            List<Ticket> TicketList = _maintenanceManager.ViewTickets();
            return Ok(TicketList);

        }

        //--------------------------------------------------------------------------------------------


        [HttpGet]
        [Route("GetWorker/{WorkerId}/{TicketId}")]
        public IActionResult GetWorker(int WorkerId, int TicketId)
        {
            User worker = _maintenanceManager.GetWorker(WorkerId, TicketId);
            return Ok(worker);
        }

        //--------------------------------------------------------------------------------------------


        [HttpGet]
        [Route("[action]")]
        [Route("ListOfWorkers/{id}")]
        public IActionResult ListOfWorkers(int TicketId)
        {
            List<User> WorkersList = _maintenanceManager.ListOfWorkers(TicketId);
            return Ok(WorkersList);

        }

        //--------------------------------------------------------------------------------------------

        [HttpGet]
        [Route("ListNewTickets")]
        public IActionResult ListNewTickets()
        {
            List<Ticket> TicketsList = _maintenanceManager.ListNewTickets();
            return Ok(TicketsList);

        }
        //--------------------------------------------------------------------------------------------

        [HttpPost]
        [Route("RespondToTicket/{TicketId}/{respond}")]
        public IActionResult RespondToTicket(int TicketId, TicketRespond respond)
        {
            _maintenanceManager.RespondToTicket(TicketId, respond);
            return Ok();

        }
        //--------------------------------------------------------------------------------------------

        [HttpPost]
        [Route("ViewUnderReviewTickets")]
        public IActionResult ViewUnderReviewTickets()
        {
            _maintenanceManager.ViewUnderReviewTickets();
            return Ok();

        }
        //--------------------------------------------------------------------------------------------

        [HttpGet]
        [Route("ViewMainteneceType")]
        public IActionResult ViewMainteneceType()
        {
            _maintenanceManager.ViewMainteneceType();
            return Ok();

        }
        //--------------------------------------------------------------------------------------------

        [HttpPost]
        [Route("AddMainteneceType/{NewType}")]
        public IActionResult AddMainteneceType(MaintenanceType NewType)
        {
            _maintenanceManager.AddMainteneceType(NewType);
            return Ok();
        }
        //--------------------------------------------------------------------------------------------

        [HttpPost]
        [Route("UpdateMainteneceType/{UpdatedType}")]
        public IActionResult UpdateMainteneceType(MaintenanceType UpdatedType)
        {
            _maintenanceManager.UpdateMainteneceType(UpdatedType);
            return Ok();
        }
        //--------------------------------------------------------------------------------------------

        [HttpDelete]
        [Route("DeleteMainteneceType/{DeletedType}")]
        public IActionResult DeleteMainteneceType(MaintenanceType DeletedType)
        {
            _maintenanceManager.DeleteMainteneceType(DeletedType);
            return Ok();
        }
    }
}
