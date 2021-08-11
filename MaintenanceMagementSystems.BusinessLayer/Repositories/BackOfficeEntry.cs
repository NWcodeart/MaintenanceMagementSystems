using MaintenanceManagementSystem.Application.Interfaces;
using MaintenanceManagementSystem.Database.Models;
using MaintenanceManagementSystem.Entity.ModelsDto;
using Microsoft.AspNetCore.Http;
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

        public BackOfficeEntry(MaintenanceSysContext maintenanceSysContext, IHttpContextAccessor httpContextAccessor)
        {
            _maintenanceSysContext = maintenanceSysContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public User AuthenticateUser(Login Login)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    var user = _maintenanceSysContext.Users.FirstOrDefault(l => l.Email == Login.Username);

                    if (user != null && BCrypt.Net.BCrypt.Verify(Login.Password, user.Password))
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

        public bool ChangePassword(string userEmail, ChangePassword changePassword)
        {
            try
            {
                var user = _maintenanceSysContext.Users.FirstOrDefault(u => u.Email == userEmail);
            
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

        public string GetUserRoleFromDB(int userRoleID)
        {
            try
            {
                var userRole = _maintenanceSysContext.UserRoles.FirstOrDefault(r => r.Id == userRoleID).Role;
                return userRole;
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
    }
}
