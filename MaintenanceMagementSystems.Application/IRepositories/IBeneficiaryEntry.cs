using MaintenanceManagementSystem.Database.Models;
using MaintenanceManagementSystem.Entity.ModelsDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MaintenanceManagementSystem.Application.Interfaces
{
    public interface IBeneficiaryEntry
    {
        /*
         The portal should contain a registration page and a login page
         */
        public void Register(BeneficiaryRegistration user);

        public bool CheckExistence(string email);

        public User AuthenticateUser(Login Login);

        public int GetUserId();

        public string GetUserRole();

        /*
         in the forget password the user is asked to enter his email address
         */
        public bool ForgetPassword(string email); //then a request will be sent to the system admin to rest the password for user

        /*
         The portal can be displayed in Arabic and English user can choose one of them
         */
        public void ChangeLanguage(); //To be reviewed

        public string GetUserRoleFromDB(int userRoleID); //To be used to get role claim

        /*
         the two methods over there are for view purpose, so when beneficiary register to the system,
         he can choose his building and floor from a drop-down list
         */
        public List<Building> ListBuildings();

        public List<Floor> ListFloors(int buildingID);
    }
}
