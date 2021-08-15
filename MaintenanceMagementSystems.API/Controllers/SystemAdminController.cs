using MaintenanceMagementSystems.API.Filters;
using MaintenanceManagementSystem.Application.Interfaces;
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
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
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
        public List<BuildingsTable> GetBuildingsTable()
        {
            var BuildingsTable = new List<BuildingsTable>();
            using (_maintenanceSysContext)
            {
                BuildingsTable = _maintenanceSysContext.Buildings.Select(b => new BuildingsTable
                {
                    BuildingId = b.Id,
                    BuildingNumber = b.Number,
                    FloorTables = b.floors.Select( f => new FloorTable
                    {
                        FloorId = f.Id,
                        FloorNumber = f.Number
                    }).ToList(),
                    CountryId = b.city.CountryId,
                    Country = b.city.country.CountryNameAr,
                    CityId = b.CityId,
                    City = b.city.CityNameAr,
                    Street = b.Street,
                    BuildingManagerId = b.BuildingManagerId,
                    BuildingManagerName = b.UserbuildingManager.Name,
                    BuildingManagerEmail = b.UserbuildingManager.Email,
                    IsOwned = b.IsOwned
                }).ToList();
            }
            return BuildingsTable;
        }

        [HttpPost]
        public IActionResult AddEmployee(User user)
        {
            _SystemAdminRepo.RegisterNewEmployee(user);
            return Ok();
        }

        }
}
