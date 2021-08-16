using MaintenanceManagementSystem.Application.Interfaces;
using MaintenanceManagementSystem.Application.IRepositories;
using MaintenanceManagementSystem.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.BusinessLayer.Repositories
{
    public class SystemUser : ISystemUser
    {
        private MaintenanceSysContext _maintenanceSysContext;
        private IBackOfficeEntry _backOfficeEntry;
        public SystemUser(MaintenanceSysContext maintenanceSysContext, IBackOfficeEntry backOfficeEntry)
        {
            _maintenanceSysContext = maintenanceSysContext;
            _backOfficeEntry = backOfficeEntry;
        }
        public bool UpdateUser(User UpdatedUser)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    User user = _maintenanceSysContext.Users.Where(u => u.Id == _backOfficeEntry.GetUserId()).FirstOrDefault();

                    if(user != null)
                      {
                        user.Name = UpdatedUser.Name;
                        user.Phone = UpdatedUser.Phone;
                        user.Email = UpdatedUser.Email;
                        user.floor = UpdatedUser.floor;
                        user.building = UpdatedUser.building;
                        user.Password = UpdatedUser.Password;
                        return true;
                       }
                    return false;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
