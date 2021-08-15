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
    [Authorize(Roles = "Admin")]
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
                        return BadRequest("maintenanceType undefiend");
                    }
                    else
                    {
                        _SystemAdminRepo.AddMaintenanceType(maintenanceType.MaintenanceTypeNameAr, maintenanceType.MaintenanceTypeNameEn);
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
        [HttpDelete]
        [Route("DeleteMaintenanceType")]
        public IActionResult DeleteMaintenanceType(MaintenanceType DeleteMaintenanceType)
        {
            var AllType = _maintenanceSysContext.MaintenanceTypes;

            try
            {
                if (ModelState.IsValid)
                {
                    if (DeleteMaintenanceType.Id == 0 || !(AllType.Any(x => x.Id == DeleteMaintenanceType.Id)))
                    {
                        return BadRequest("maintenanceType undefiend");
                    }
                    else
                    {
                        _SystemAdminRepo.DeleteMaintenanceType(DeleteMaintenanceType.Id);
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
        [HttpGet]
        [Route("GetAllMaintenanceType")]
        public IActionResult GetAllMaintenanceType()
        {
            try
            {
                var MaintenanceTypesTable = _SystemAdminRepo.GetAllMaintenanceType();
                return Ok(MaintenanceTypesTable);

            }
            catch (Exception)
            {
                return BadRequest("Error Exception");
            }
        }
        [HttpGet]
        [Route("GetCancellationReason")]
        public IActionResult GetCancellationReason()
        {
            try
            {
                var CancellationReasonsTable = _SystemAdminRepo.GetCancellationReason();
                return Ok(CancellationReasonsTable);

            }
            catch (Exception)
            {
                return BadRequest("Error Exception");
            }
        }
        [HttpPost]
        [Route("AddCancellationReason")]
        public IActionResult AddCancellationReason(CancellationReason cancellationReason)
        {
            var AllReasons = _maintenanceSysContext.CancelationReasons;

            try
            {
                if (ModelState.IsValid)
                {
                    if (cancellationReason.Id == 0 || !(AllReasons.Any(x => x.Id == cancellationReason.Id)))
                    {
                        return BadRequest("cancellation Reason undefiend");
                    }
                    else
                    {
                        _SystemAdminRepo.AddCancellationReason(cancellationReason);
                        return Ok("Cancellation Reason added successfully");
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
        [HttpDelete]
        [Route("DeleteCancellationReason")]
        public IActionResult DeleteCancellationReason(CancellationReason cancellationReason)
        {
            var AllReasons = _maintenanceSysContext.CancelationReasons;

            try
            {
                if (ModelState.IsValid)
                {
                    if (cancellationReason.Id == 0 || !(AllReasons.Any(x => x.Id == cancellationReason.Id)))
                    {
                        return BadRequest("cancellation Reason undefiend");
                    }
                    else
                    {
                        _SystemAdminRepo.DeleteCancellationReason(cancellationReason.Id);
                        return Ok("cancellation Reason deleted successfully");
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
        [HttpDelete]
        [Route("DeleteUser")]
        public IActionResult DeleteUser(User DeletedUser)
        {
            var AllUsers = _maintenanceSysContext.Users;

            try
            {
                if (ModelState.IsValid)
                {
                    if (DeletedUser.Id == 0 || !(AllUsers.Any(x => x.Id == DeletedUser.Id)))
                    {
                        return BadRequest("user undefiend");
                    }
                    else
                    {
                        _SystemAdminRepo.DeleteCancellationReason(DeletedUser.Id);
                        return Ok("user deleted successfully");
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
        [Route("UpdateUser")]
        public IActionResult UpdateUser(User UpdatedUser)
        {
            var AllUsers = _maintenanceSysContext.Users;

            try
            {
                if (ModelState.IsValid)
                {
                    if (UpdatedUser.Id == 0 || !(AllUsers.Any(x => x.Id == UpdatedUser.Id)))
                    {
                        return BadRequest("user undefiend");
                    }
                    else
                    {
                        _SystemAdminRepo.UpdateUser(UpdatedUser);
                        return Ok("user updated successfully");
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
        [Route("ResetUserPassword")]
        public IActionResult ResetUserPassword(User UpdatedPassUser)
        {
            var AllUsers = _maintenanceSysContext.Users;

            try
            {
                if (ModelState.IsValid)
                {
                    if (UpdatedPassUser.Id == 0 || !(AllUsers.Any(x => x.Id == UpdatedPassUser.Id)))
                    {
                        return BadRequest("user undefiend");
                    }
                    else
                    {
                        _SystemAdminRepo.ResetUserPassword(UpdatedPassUser.Id, UpdatedPassUser.Password);
                        return Ok("user password updated successfully");
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
    }
}
     