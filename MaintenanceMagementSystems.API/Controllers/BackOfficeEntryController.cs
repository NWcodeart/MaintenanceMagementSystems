﻿using MaintenanceManagementSystem.Application.Interfaces;
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
    [Authorize(Roles = "SystemAdmin,BuildingManager,MaintenanceManager,MaintenanceWorker")]
    [Route("api/[controller]")]
    [ApiController]
    public class BackOfficeEntryController : ControllerBase
    {
        private IBackOfficeEntry _backOfficeEntry;
        private IConfiguration _config;

        public BackOfficeEntryController(IBackOfficeEntry backOfficeEntry, IConfiguration config)
        {
            _backOfficeEntry = backOfficeEntry;
            _config = config;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public IActionResult Login(Login login)
        {
            IActionResult response = Unauthorized("Incorrect username or password");

            var user = _backOfficeEntry.AuthenticateUser(login);

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
            var roleString = _backOfficeEntry.GetUserRoleFromDB(User.UserRoleId);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, User.Email),
                new Claim(ClaimTypes.Role, roleString),
                new Claim(ClaimTypes.Sid, User.Id.ToString()),
                new Claim("BuildingID", User.buildingId.ToString()),
                new Claim("FloorID", User.FloorId.ToString())
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
            return Ok(_backOfficeEntry.GetUserRole());
        }

        [Authorize(Roles = "Back Office")]
        [HttpPost]
        [Route("ForgotPassword")]
        public IActionResult ForgotPassword([FromBody] string Email)
        {
            if (!(_backOfficeEntry.ForgotPassword(Email)))
            {
                return NotFound("User with given email in not found");
            }
            else
            {
                return Ok("New password will be sent to you soon");
            }
        }

        [HttpPost]
        [Route("ChangePassword")]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            if (!(_backOfficeEntry.ChangePassword(changePassword)))
            {
                return BadRequest("Unmatched passwords, you can log out and choose 'forgot password' option instead");
            }
           
            return Ok();
        }

        [Authorize(Roles = "Back Office")]
        [HttpPost]
        [Route("SetAsRememberMe")]
        public IActionResult SetAsRememberMe()
        {
            if (!(_backOfficeEntry.SetAsRememberMe(_backOfficeEntry.GetUserId())))
            {
                return NotFound("User with given id in not found");
            }
            else
            {
                return Ok();
            }
        }

    }
}
