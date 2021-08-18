using MaintenanceManagementSystem.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Application.IRepositories
{
    public interface ISystemUser
    {
        public bool UpdateUser(User UpdatedUser);
        public bool SendEmail(string email);
        public bool ResetPassword(Guid tempPassword, string newPassword);

    }
}
