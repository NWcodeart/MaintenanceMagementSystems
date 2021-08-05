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
    public class BeneficiaryEntry
    {
        private MaintenanceSysContext _maintenanceSysContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BeneficiaryEntry(MaintenanceSysContext maintenanceSysContext, IHttpContextAccessor httpContextAccessor)
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

                    Login.Password = BCrypt.Net.BCrypt.HashPassword(Login.Password, BCrypt.Net.BCrypt.GenerateSalt(user.Id));

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
                        user.ForgetPassword = true;
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
            ClaimsPrincipal currentUser = _httpContextAccessor.HttpContext.User;
            var stringClaimValue = currentUser.FindFirst(ClaimTypes.Sid).Value;
            var IdNumber = Convert.ToInt32(stringClaimValue);
            return IdNumber;
        }

        public string GetUserRole()
        {
            ClaimsPrincipal currentUser = _httpContextAccessor.HttpContext.User;
            var stringClaimValue = currentUser.FindFirst(ClaimTypes.Role).Value;
            return stringClaimValue;
        }

        public void Register(BeneficiaryRegistration user)
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
                        Phone = user.Phone
                    };

                    newUser.Password = BCrypt.Net.BCrypt.HashPassword(user.Password, BCrypt.Net.BCrypt.GenerateSalt(newUser.Id));

                    _maintenanceSysContext.Users.Add(newUser);
                    _maintenanceSysContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
