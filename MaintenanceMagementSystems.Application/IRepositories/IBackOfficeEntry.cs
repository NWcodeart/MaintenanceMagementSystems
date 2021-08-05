using MaintenanceManagementSystem.Database.Models;
using MaintenanceManagementSystem.Entity.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Application.Interfaces
{
    public interface IBackOfficeEntry
    {
        /*
         No registration page needed just login using their employees ID (Email)
         */
        public bool CheckExistence(string email);

        /*
         Employees must be asked to change their password to a complex password on the 
         1st login to the back-office portal
         */
        public bool ChangePassword(ChangePassword passwords);
    }
}
