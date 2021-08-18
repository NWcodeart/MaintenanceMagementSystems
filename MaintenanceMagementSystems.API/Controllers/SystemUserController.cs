using MaintenanceMagementSystems.API.Filters;
using MaintenanceManagementSystem.Application.IRepositories;
using MaintenanceManagementSystem.Database.Models;
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
    [Route("api/[controller]")]
    [ApiController]

    public class SystemUserController : Controller
    {
        
        private readonly ISystemUser _systemUser;

        public SystemUserController(ISystemUser systemUser)
        {
            _systemUser = systemUser;
        }


            [HttpPost]
            [Route("[action]")]
            [ActionName("UpdateUser/{user}")]
            public IActionResult UpdateUser(User user)
            {
                _systemUser.UpdateUser(user);
                return Ok();
            }

            //--------------------------------------------------------------------------------------------

    }
}
