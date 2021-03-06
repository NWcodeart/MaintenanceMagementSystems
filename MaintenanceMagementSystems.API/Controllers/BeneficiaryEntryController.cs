using MaintenanceMagementSystems.API.Filters;
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
    [ServiceFilter(typeof(AuthorizeFilter))]
    [ServiceFilter(typeof(ActionFilter))]
    [ServiceFilter(typeof(ExceptionFilter))]
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
        public IActionResult Register(RegistrationDto user)
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
            if(user == null)
            {
                return response;
            }

            if (user != null)
            {
                string tokenString = GenerateJSONWebToken(user);
                response = Ok(tokenString);
            }

            return response;

        }

        private string GenerateJSONWebToken(User User)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var roleString = _beneficiaryEntryRepo.GetUserRoleFromDB(User.UserRoleId);

            List<Claim> claims = new List<Claim>();


                claims.Add(new Claim(JwtRegisteredClaimNames.Email, User.Email));
                claims.Add(new Claim(ClaimTypes.Role, roleString.Result));
            claims.Add(new Claim(ClaimTypes.Sid, User.Id.ToString()));
            claims.Add(new Claim("BuildingID", User.buildingId.ToString()));
            claims.Add(new Claim("FloorID", User.FloorId.ToString()));

            var identity = HttpContext.User.Identity as ClaimsIdentity;

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddDays(1),
              signingCredentials: credentials);
            identity.AddClaims(claims);
            var claimPrincipal = new ClaimsPrincipal(identity);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [Authorize]
        [HttpGet]
        [Route("GetRole")]
        public IActionResult GetRole()
        {
          string Token =  Request.HttpContext.Session.GetString("Token");
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(Token);
            var tokenS = jsonToken as JwtSecurityToken;
            var jti = tokenS.Claims;
            return Ok(_beneficiaryEntryRepo.GetUserRole());
        }

        [AllowAnonymous]
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

        [AllowAnonymous]
        [HttpGet]
        [Route("ListBuildings")]
        public IActionResult ListBuildings()
        {
            var buildings = _beneficiaryEntryRepo.ListBuildings();
            if (buildings.Count() == 0)
            {
                return NotFound("There are no buildings");
            }

            return Ok(buildings);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("ListFloors/{buildingID}")]
        public IActionResult ListFloors(int buildingID)
        {
            var floors = _beneficiaryEntryRepo.ListFloors(buildingID);
            if (floors.Count() == 0)
            {
                return NotFound("There are no floors");
            }

            return Ok(floors);
        }
    }
}
