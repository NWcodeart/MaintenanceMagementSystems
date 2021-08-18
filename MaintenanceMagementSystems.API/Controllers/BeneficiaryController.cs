using MaintenanceMagementSystems.API.Filters;
using MaintenanceManagementSystem.Application.Interfaces;
using MaintenanceManagementSystem.Database.Models;
using MaintenanceManagementSystem.Entity.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.API.Controllers
{
    [ServiceFilter(typeof(AuthorizeFilter))]
    [ServiceFilter(typeof(ActionFilter))]
    [ServiceFilter(typeof(ExceptionFilter))]
    [Authorize(Roles = "Beneficiary,SystemAdmin,BuildingManager,MaintenanceManager,MaintenanceWorker")]
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiaryController : ControllerBase
    {
        private IBeneficiary _beneficiaryRepo;

        public BeneficiaryController(IBeneficiary beneficiaryrepo)
        {
            _beneficiaryRepo = beneficiaryrepo;
        }
        
        [HttpPost]
        [Route("SubmitRequest")]
        public IActionResult SubmitRequest(TicketRequest ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            else if (!_beneficiaryRepo.SubmitTicket(ticket))
            {
                return BadRequest("You cannot request a new ticket while you have an active ticket");
            }

            _beneficiaryRepo.SubmitTicket(ticket);
            return Ok("Request has been submitted successfully");
            
        }

        [HttpPatch]
        [Route("ConfirmRequest/{requestID}")]
        public IActionResult ConfirmRequest(int requestID)
        {
            if (!(_beneficiaryRepo.ConfirmTicket(requestID)))
            {
                return NotFound("Request with given ID is not found");
            }

            return Ok("Request has been confirmed successfully");
        }

        [HttpPatch]
        [Route("CancelRequest/{requestID}/{cancelationReasonID}")]
        public IActionResult CancelRequest(int requestID, int cancelationReasonID)
        {
            if (!(_beneficiaryRepo.CancelTicket(requestID, cancelationReasonID)))
            {
                return NotFound("Request with given ID is not found or it's already sent to the maintenance manager");
            }

            return Ok("Request has been canceled successfully");
        }

        [HttpGet]
        [Route("ListTickets")]
        public IActionResult ListTickets()
        {
            if (_beneficiaryRepo.ListAllTickets().Count() == 0)
            {
                return NotFound("No tickets available");
            }

            return Ok(_beneficiaryRepo.ListAllTickets());
        }

        [HttpGet]
        [Route("GetTicket/{requestID}")]
        public IActionResult GetTicket(int requestID)
        {
            if(_beneficiaryRepo.GetTicket(requestID) == null)
            {
                return NotFound("Ticket with given ID is not found");
            }

            return Ok(_beneficiaryRepo.GetTicket(requestID));
        }

        [HttpGet]
        [Route("ListCancellationReasons")]
        public IActionResult ListCancellationReasons()
        {
            if(_beneficiaryRepo.ListCancellationReasons().Count() == 0)
            {
                return NotFound("No rancellation reasons available");
            }

            return Ok(_beneficiaryRepo.ListCancellationReasons());
        }

        
    }
}
