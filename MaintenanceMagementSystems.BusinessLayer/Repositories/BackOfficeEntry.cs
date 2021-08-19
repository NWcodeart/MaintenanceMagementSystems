using MaintenanceManagementSystem.Application.Interfaces;
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

namespace MaintenanceManagementSystem.BusinessLayer.Repositories
{
    public class BackOfficeEntry : IBackOfficeEntry
    {
        private readonly MaintenanceSysContext _maintenanceSysContext;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DbContextOptions<MaintenanceSysContext> _options;

        public BackOfficeEntry(MaintenanceSysContext maintenanceSysContext, 
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
                using (_maintenanceSysContext)
                {
                    var user = _maintenanceSysContext.Users.FirstOrDefault(l => l.Email == Login.Username);

                    if (!(user == null) && BCrypt.Net.BCrypt.Verify(Login.Password, user.Password))
                    {
                        return user;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ChangePassword(ChangePassword changePassword)
        {
            try
            {
                var user = _maintenanceSysContext.Users.FirstOrDefault(u => u.Id == GetUserId());
            
                if (user != null && BCrypt.Net.BCrypt.Verify(changePassword.CurrentPassword, user.Password))
                {
                    user.Password = BCrypt.Net.BCrypt.HashPassword(changePassword.NewPassword);
                    _maintenanceSysContext.SaveChanges();
                    return true;
                }

                return false;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ForgotPassword(string email)
        {
            try
            {
                var user = _maintenanceSysContext.Users.FirstOrDefault(u => u.Email == email);
                if (user != null)
                {
                    user.IsForgetPassword = true;
                    _maintenanceSysContext.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool SetAsRememberMe(int userID)
        {
            try
            {
                var user = _maintenanceSysContext.Users.FirstOrDefault(u => u.Id == userID);
                if (user != null)
                {
                    user.IsRememberMe = true;
                    _maintenanceSysContext.SaveChanges();
                    return true;
                }

                return false;
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

        public int GetUserId()
        {
            try
            {
                    var currentUser = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
                    var stringClaimValue = currentUser.FindFirst(ClaimTypes.Sid).Value;
                    var IdNumber = Convert.ToInt32(stringClaimValue);
                    return IdNumber;
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

                var currentUser = _httpContextAccessor.HttpContext.User.Identity as ClaimsIdentity;
                var stringClaimValue = currentUser.FindFirst(ClaimTypes.Role).Value;
                    return stringClaimValue;
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string GetUserEmail()
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    ClaimsPrincipal currentUser = _httpContextAccessor.HttpContext.User;
                    var stringClaimValue = currentUser.FindFirst(ClaimTypes.Email).Value;
                    return stringClaimValue;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RegisterSystemAdmin(RegistrationDto user)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    var newUser = new User()
                    {
                        UserRoleId = 1,
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
    }
}
