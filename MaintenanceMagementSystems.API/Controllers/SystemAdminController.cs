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
        [AllowAnonymous]
        [HttpPost]
        [Route("AddBuilding")]
        public IActionResult AddBuilding(Building building)
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
        [AllowAnonymous]
        [HttpGet]
        [Route("GetBuildingsTable")]
        public IActionResult GetBuildingsTable()
        {
            List<BuildingsTable> buildingsTables = _SystemAdminRepo.GetBuildings();
            return Ok(buildingsTables);
        }
        [AllowAnonymous]
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
        [AllowAnonymous]
        [HttpPost]
        [Route("UpdateBuilding")]
        public IActionResult UpdateBuilding(Building BuildingUpdated)
        {
            var AllBuilding = _maintenanceSysContext.Buildings;

            try
            {
                if (ModelState.IsValid)
                {
                    if (BuildingUpdated.Id == 0 || !(AllBuilding.Any(x => x.Id == BuildingUpdated.Id)))
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

        [AllowAnonymous]
        [HttpPost]
        [Route("AddMaintenanceType")]
        public IActionResult AddMaintenanceType(MaintenanceType maintenanceType)
        {
            var AllType = _maintenanceSysContext.MaintenanceTypes;

            try
            {
                if (ModelState.IsValid)
                {
                    if (maintenanceType.Id == 0 || !(AllType.Any(x => x.Id == maintenanceType.Id)))
                    {
                        return BadRequest("Building undefiend");
                    }
                    else
                    {
                        //_SystemAdminRepo.AddMaintenanceType(maintenanceType);
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

        [AllowAnonymous]
        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(User user)
        {
            _SystemAdminRepo.RegisterNewEmployee(user);
            return Ok();
        }
        [AllowAnonymous]
        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(User user)
        {
            _SystemAdminRepo.DeleteUser(user.Id);
            return Ok();
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("UpdateUser")]
        public IActionResult UpdateUser(User user)
        {
            _SystemAdminRepo.UpdateUser(user);
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            var users = _SystemAdminRepo.GetUsers();
            return Ok(users);
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("GetCountries")]
        public IActionResult GetCountries()
        {
            var countries = _SystemAdminRepo.GetCountrys();
            return Ok(countries);
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("AddCountry")]
        public IActionResult AddCountry(Country country)
        {
            _SystemAdminRepo.AddCountry(country);
            return Ok();
        }
        [AllowAnonymous]
        [HttpDelete]
        [Route("DeleteCountry")]
        public IActionResult DeleteCountry(int id)
        {
            _SystemAdminRepo.DeleteCountry(id);
            return Ok();
        }
        [HttpPost]
        [Route("AddCity")]
        public IActionResult AddCity(City city)
        {
            _SystemAdminRepo.AddCity(city);
            return Ok();
        }
        [AllowAnonymous]
        [HttpDelete]
        [Route("DeleteCity")]
        public IActionResult DeleteCity(int id)
        {
            _SystemAdminRepo.DeleteCity(id);
            return Ok();
        }



    }
}
     