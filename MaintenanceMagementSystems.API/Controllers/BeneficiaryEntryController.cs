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
    public class BeneficiaryEntryController : ControllerBase
    {
        private IBeneficiaryEntry _beneficiaryEntryRepo;
        private IConfiguration _config;

        public BeneficiaryEntryController(IBeneficiaryEntry beneficiaryEntryRepo, IConfiguration config)
        {
            _beneficiaryEntryRepo = beneficiaryEntryRepo;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(BeneficiaryRegistration user)
        {
            if (_beneficiaryEntryRepo.CheckExistence(user.Email))
            {
                return BadRequest("You are already registered");
            }
            else
            {
                _beneficiaryEntryRepo.Register(user);
                return Ok("You have been registered successfully");
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(Login login)
        {
            IActionResult response = Unauthorized("Incorrect username or password");

            var user = _beneficiaryEntryRepo.AuthenticateUser(login);

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
              expires: DateTime.Now.AddDays(1),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [Authorize]
        [HttpGet]
        [Route("GetRole")]
        public IActionResult GetRole()
        {
            return Ok(_beneficiaryEntryRepo.GetUserRole());
        }

        [Authorize(Roles = "Beneficiary")]
        [HttpPost]
        [Route("ChangePassword")]
        public IActionResult ChangePassword([FromBody] string Email)
        {
            if (!(_beneficiaryEntryRepo.ForgetPassword(Email)))
            {
                return NotFound("User with given email in not found");
            }
            else
            {
                return Ok("New password will be sent to you soon");
            }
        }
    }
}
