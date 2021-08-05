using MaintenanceManagementSystem.Application.Interfaces;
using MaintenanceManagementSystem.Database.Models;
using MaintenanceManagementSystem.Entity.ModelsDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
    [Route("api/[controller]")]
    [ApiController]
    public class BeneficiaryController : ControllerBase
    {
        private IBeneficiary _beneficiaryRepo;
        private IConfiguration _config;

        public BeneficiaryController(IBeneficiary beneficiaryrepo, IConfiguration config)
        {
            _beneficiaryRepo = beneficiaryrepo;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(BeneficiaryRegistration user)
        {
            if (_beneficiaryRepo.CheckExistence(user.Email))
            {
                return BadRequest("Username already exists");
            }
            else
            {
                _beneficiaryRepo.Register(user);
                return Ok("You have been registered successfully");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(Login login)
        {
            IActionResult response = Unauthorized();

            var user = _beneficiaryRepo.AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(tokenString);
            }

            return response;

        }

        private string GenerateJSONWebToken(User User)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, User.Email),
                new Claim(ClaimTypes.Role, User.userRole.Role),
                new Claim(ClaimTypes.Sid, User.Id.ToString())
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [Authorize]
        [HttpGet]
        [Route("GetRole")]
        public IActionResult GetRole()
        {
            return Ok(_beneficiaryRepo.GetUserRole());
        }

        [Authorize]
        [HttpPost]
        [Route("ChangePassword")]
        public IActionResult ChangePassword([FromBody] string Email)
        {
            if (!(_beneficiaryRepo.ForgetPassword(Email)))
            {
                return NotFound("User with given email in not found");
            }
            else
            {
                return Ok("New password will be sent to you soon");
            }
        }

        [Authorize(Roles = "Beneficiary")]
        [HttpPost]
        [Route("SubmitRequest")]
        public IActionResult SubmitRequest(Ticket ticket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Data");
            }
            else
            {
                _beneficiaryRepo.SubmitRequest(_beneficiaryRepo.GetUserId(), ticket);
                return Ok("Request has been submitted successfully");
            }

        }

        [Authorize(Roles = "Beneficiary")]
        [HttpPatch]
        [Route("ConfirmRequest/{requestID}")]
        public IActionResult ConfirmRequest(int requestID)
        {
            if (!(_beneficiaryRepo.ConfirmRequest(_beneficiaryRepo.GetUserId(), requestID)))
            {
                return NotFound("Request with given ID is not found");
            }
            return Ok("Request has been confirmed successfully");
        }

        [Authorize(Roles = "Beneficiary")]
        [HttpPatch]
        [Route("CancelRequest/{requestID}")]
        public IActionResult CancelRequest(int requestID)
        {
            if (!(_beneficiaryRepo.CancelRequest(_beneficiaryRepo.GetUserId(), requestID)))
            {
                return NotFound("Request with given ID is not found");
            }
            return Ok("Request has been canceled successfully");
        }
    }
}
