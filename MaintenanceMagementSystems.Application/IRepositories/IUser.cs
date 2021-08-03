using MaintenanceManagementSystem.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Application.Interfaces
{
    public interface IUser // interface IAdmin : IUser,  BM, MM, Worker
    {
        public bool AddBeneficiary(User user);
        public void AddBackOffice(string email); //admins will add BackOffice emloyees
        public bool CheckExistence(string email, string password);
        public bool ForgetPassword(string email);
        public bool ChangePassword(string password);
        public void ChangeLanguage(); //?????????????????
    }
}
