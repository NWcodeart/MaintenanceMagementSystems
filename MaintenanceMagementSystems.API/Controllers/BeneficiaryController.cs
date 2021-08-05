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
    [Authorize(Roles = "Beneficiary")]
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiaryController : ControllerBase
    {
        private IBeneficiary _beneficiaryRepo;
        private IBeneficiaryEntry _beneficiaryEntryRepo;

        public BeneficiaryController(IBeneficiary beneficiaryrepo, IBeneficiaryEntry beneficiaryEntryRepo)
        {
            _beneficiaryRepo = beneficiaryrepo;
            _beneficiaryEntryRepo = beneficiaryEntryRepo;
        }
        
        [HttpPost]
        [Route("SubmitRequest")]
        public IActionResult SubmitRequest(TicketRequest ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            else
            {
                _beneficiaryRepo.SubmitTicket(_beneficiaryEntryRepo.GetUserId(), ticket);
                return Ok("Request has been submitted successfully");
            }

        }

        [HttpPatch]
        [Route("ConfirmRequest/{requestID}")]
        public IActionResult ConfirmRequest(int requestID)
        {
            if (!(_beneficiaryRepo.ConfirmTicket(_beneficiaryEntryRepo.GetUserId(), requestID)))
            {
                return NotFound("Request with given ID is not found");
            }
            return Ok("Request has been confirmed successfully");
        }

        [HttpPatch]
        [Route("CancelRequest/{requestID}")]
        public IActionResult CancelRequest(int requestID)
        {
            if (!(_beneficiaryRepo.CancelTicket(_beneficiaryEntryRepo.GetUserId(), requestID)))
            {
                return NotFound("Request with given ID is not found");
            }
            return Ok("Request has been canceled successfully");
        }
    }
}
