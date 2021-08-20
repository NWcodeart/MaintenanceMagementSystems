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

        [HttpGet]
        [Route("ConfirmRequest/{requestID}")]
        public IActionResult ConfirmRequest(int requestID)
        {
            if (!(_beneficiaryRepo.ConfirmTicket(requestID)))
            {
                return NotFound("An incomplete request cannot be confirmed");
            }

            return Ok("Request has been confirmed successfully");
        }

        [HttpPatch]
        [Route("CancelRequest/{requestID}")]
        public IActionResult CancelRequest(int requestID, [FromBody] int cancellationReason)
        {
            if (!(_beneficiaryRepo.CancelTicket(requestID, cancellationReason)))
            {
                return NotFound("The request is either under processing and can't be canceled or it's already canceled");
            }

            return Ok("Request has been canceled successfully");
        }
        [AllowAnonymous]
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
                return NotFound("No cancellation reasons available");
            }

            return Ok(_beneficiaryRepo.ListCancellationReasons());
        }

        [HttpGet]
        [Route("ListMaintenanceTypes")]
        public IActionResult ListMaintenanceTypes()
        {
            if (_beneficiaryRepo.ListMaintenanceTypes().Count() == 0)
            {
                return NotFound("No cancellation reasons available");
            }

            return Ok(_beneficiaryRepo.ListMaintenanceTypes());
        }
        [HttpGet]
        [Route("GetUserInfo")]
        public IActionResult GetUserInfo()
        {
            UserInfoBeneficiary user = _beneficiaryRepo.GetUserInfo();
            if (user == null || user.IsDeleted == true)
            {
                return NotFound("No Account available");
            }

            return Ok(user);
        }
    }
}
