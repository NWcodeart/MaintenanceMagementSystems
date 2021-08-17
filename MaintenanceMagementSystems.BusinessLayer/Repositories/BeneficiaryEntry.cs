using MaintenanceManagementSystem.Application.Interfaces;
using MaintenanceManagementSystem.Database.Lookup;
using MaintenanceManagementSystem.Database.Models;
using MaintenanceManagementSystem.Entity.ModelsDto;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MaintenanceManagementSystem.BusinessLayer.Repositories
{
    public class BeneficiaryEntry : IBeneficiaryEntry
    {
        private readonly MaintenanceSysContext _maintenanceSysContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DbContextOptions<MaintenanceSysContext> _options;

        public BeneficiaryEntry(MaintenanceSysContext maintenanceSysContext,
            IHttpContextAccessor httpContextAccessor,
            DbContextOptions<MaintenanceSysContext> options)
        {
            _maintenanceSysContext = maintenanceSysContext;
            _httpContextAccessor = httpContextAccessor;
            _options = options;
        }

        public User AuthenticateUser(Login Login)
        {
            try
            {
                using (var db = new MaintenanceSysContext(_options))
                {
                    var user = _maintenanceSysContext.Users.FirstOrDefault(l => l.Email == Login.Username);

                    if (user != null && BCrypt.Net.BCrypt.Verify(Login.Password, user.Password))
                    {
                        return user;
                    }
                    else { 
                        
                        return null;
                    }
                    
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public void ChangeLanguage()
        {
            throw new NotImplementedException();
        }


        public bool CheckExistence(string email)
        {
            try
            {
                var user = _maintenanceSysContext.Users.FirstOrDefault(u => u.Email == email);
                if (user != null)
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ForgetPassword(string email)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    User user = _maintenanceSysContext.Users.FirstOrDefault(u => u.Email == email);
                    if (user != null)
                    {
                        user.IsForgetPassword = true;
                        _maintenanceSysContext.SaveChanges();
                        return true;
                    }

                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int GetUserId()
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    ClaimsPrincipal currentUser = _httpContextAccessor.HttpContext.User;
                    var stringClaimValue = currentUser.FindFirst(ClaimTypes.Sid).Value;
                    var IdNumber = Convert.ToInt32(stringClaimValue);
                    return IdNumber;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetUserRole()
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    ClaimsPrincipal currentUser = _httpContextAccessor.HttpContext.User;
                    var stringClaimValue = currentUser.FindFirst(ClaimTypes.Role).Value;
                    return stringClaimValue;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Register(BeneficiaryRegistration user)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    var newUser = new User()
                    {
                        UserRoleId = 5,
                        Name = user.Name,
                        Email = user.Email,
                        Phone = user.Phone,
                        buildingId = user.BuildingNumber,
                        FloorId = user.FloorNumber
                    };

                    newUser.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

                    _maintenanceSysContext.Users.Add(newUser);
                    _maintenanceSysContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> GetUserRoleFromDB(int userRoleID)
        {
            try
            {
               
                using (var db = new MaintenanceSysContext(_options))
                {
                    var userRole = await db.UserRoles.FirstOrDefaultAsync(r => r.Id == userRoleID);
                    var roleType = userRole.RoleType;
                    return roleType;
                }
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public List<Building> ListBuildings()
        {
            try
            {
                var buildings = _maintenanceSysContext.Buildings.ToList();
                return buildings; 
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Floor> ListFloors(int buildingID)
        {
            try
            {
                var floors = _maintenanceSysContext.Floors.Where(f => f.BuildingId == buildingID).ToList();
                return floors;              
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
