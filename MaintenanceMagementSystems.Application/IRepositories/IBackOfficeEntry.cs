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
        public User AuthenticateUser(Login Login);

        /*
         in the forget password the employee is asked to enter his email address
         */
        public bool ForgotPassword(string email);

        /*
         and then a request will be sent to that email containing a temporary that the employee 
         can use to change his password
        + Employees must be asked to change their password to a complex password on the 
        1st login to the back-office portal
        */
        public bool ChangePassword(ChangePassword changePassword);

        /*
         Remember me option, just setting that option
         */
        public bool SetAsRememberMe(int userID);

        public int GetUserId(); //from claims

        public string GetUserRole();

        public Task<string> GetUserRoleFromDB(int userRoleID); //To be used to get role claim

        public string GetUserEmail();

    }
}
