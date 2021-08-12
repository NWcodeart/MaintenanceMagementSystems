﻿using MaintenanceManagementSystem.Application.Interfaces;
using MaintenanceManagementSystem.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceWorkerController : ControllerBase
    {
        private readonly IMaintenanceWorker _maintenanceWorker;
        public MaintenanceWorkerController(IMaintenanceWorker maintenanceWoker)
        {
            _maintenanceWorker = maintenanceWoker;
        }


        [HttpGet]
        [Route("GetTicket/{id}")]
        public IActionResult GetTicket(int TicketId)
        {
            Ticket ticket = _maintenanceWorker.GetTicket(TicketId);
            return Ok(ticket);
        }

        //--------------------------------------------------------------------------------------------

        [HttpGet]
        [Route("ViewTickets")]
        public IActionResult ListTickets()
        {
            List<Ticket> TicketList = _maintenanceWorker.ListTickets();
            return Ok(TicketList);

        }

        //--------------------------------------------------------------------------------------------

        [HttpPost]
        [Route("AcceptingTicket")]
        public IActionResult AcceptingTicket(int TicketId)
        {
             _maintenanceWorker.AcceptingTicket(TicketId);
            return Ok();

        }
    }
}
