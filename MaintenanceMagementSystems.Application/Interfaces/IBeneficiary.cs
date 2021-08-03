using MaintenanceManagementSystem.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Application.Interfaces
{
    public interface IBeneficiary
    {
        public bool Register(User user);
        public bool CheckExistence(string email, string password); //for login
        public bool ForgetPassword(string email);
        public bool ChangePassword(string password);
        public void ChangeLanguage(); //?????????????????
    }
}
