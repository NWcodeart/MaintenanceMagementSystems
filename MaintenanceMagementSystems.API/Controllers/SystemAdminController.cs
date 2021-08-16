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
    [Authorize(Roles = "SystemAdmin")]
    [Route("api/SystemAdmin")]
    [ApiController]
    public class SystemAdminController : ControllerBase
    {
        private ISystemAdmin _SystemAdminRepo;
        private MaintenanceSysContext _maintenanceSysContext;

        public SystemAdminController(ISystemAdmin systemAdminRepo, MaintenanceSysContext maintenanceSysContext)
        {
            _SystemAdminRepo = systemAdminRepo;
            _maintenanceSysContext = maintenanceSysContext;
        }
        [HttpPost]
        public IActionResult AddBulding(Building building)
        {
            var AllBuilding = _maintenanceSysContext.Buildings;

            try
            {
                if (ModelState.IsValid)
                {
                    if(building == null || !(AllBuilding.Any(x => x.Id == building.Id)))
                    {
                        return BadRequest("Building undefiend");
                    }
                    else
                    {
                        //try to set this function boolean to take Sure is building added succesfully or not
                        _SystemAdminRepo.AddBuilding(building);
                        return Ok("Building added successfully");
                    }
                    
                }
                else
                {
                    return BadRequest("Model State is invalid");
                }
                
            }
            catch (Exception)
            {
                return BadRequest("Error Exception");
            }
            
        }
        [HttpGet]
        [Route("GetBuildingsTable")]
        public IActionResult GetBuildingsTable()
        {
            List<BuildingsTable> buildingsTables = _SystemAdminRepo.GetBuildings();
            return Ok(buildingsTables);
        }
        [HttpDelete]
        [Route("DeleteBuilding")]
        public IActionResult DeleteBuilding(int id = 0)
        {
            var AllBuilding = _maintenanceSysContext.Buildings;

            try
            {
                if (ModelState.IsValid)
                {
                    if (id == 0 || !(AllBuilding.Any(x => x.Id == id)))
                    {
                        return BadRequest("Building undefiend");
                    }
                    else
                    {
                        _SystemAdminRepo.DeleteBuilding(id);
                        return Ok("Building delete successfully");
                    }

                }
                else
                {
                    return BadRequest("Model State is invalid");
                }

            }
            catch (Exception)
            {
                return BadRequest("Error Exception");
            }
        }
        [HttpPost]
        [Route("UpdateBuilding")]
        public IActionResult UpdateBuilding(Building BuildingUpdated)
        {
            var AllBuilding = _maintenanceSysContext.Buildings;

            try
            {
                if (ModelState.IsValid)
                {
                    if (BuildingUpdated.Id == null || !(AllBuilding.Any(x => x.Id == BuildingUpdated.Id)))
                    {
                        return BadRequest("Building undefiend");
                    }
                    else
                    {
                        _SystemAdminRepo.UpdateBuilding(BuildingUpdated);
                        return Ok("Building updated successfully");
                    }

                }
                else
                {
                    return BadRequest("Model State is invalid");
                }

            }
            catch (Exception)
            {
                return BadRequest("Error Exception");
            }
        }

        //look up operations 

        [HttpPost]
        [Route("AddMaintenanceType")]
        public IActionResult AddMaintenanceType(MaintenanceType maintenanceType)
        {
            var AllType = _maintenanceSysContext.MaintenanceTypes;

            try
            {
                if (ModelState.IsValid)
                {
                    if (maintenanceType.Id == null || !(AllType.Any(x => x.Id == maintenanceType.Id)))
                    {
                        return BadRequest("Building undefiend");
                    }
                    else
                    {
                        _SystemAdminRepo.AddMaintenanceType(maintenanceType);
                        return Ok("maintenanceType added successfully");
                    }

                }
                else
                {
                    return BadRequest("Model State is invalid");
                }

            }
            catch (Exception)
            {
                return BadRequest("Error Exception");
            }
        }

        [HttpPost]
        [Route("AddEmployee")]
        public IActionResult AddEmployee(User user)
        {
            _SystemAdminRepo.RegisterNewEmployee(user);
            return Ok();
        }

    }
}
     