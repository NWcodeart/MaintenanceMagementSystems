using MaintenanceManagementSystem.Database.Lookup;
using MaintenanceManagementSystem.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Application.Interfaces
{
    public interface ISystemAdmin
    {
        /*
         System admin will register the employees and assign them their roles and privileges (Building Manager, Maintenance Manager and Maintenance Worker)
         */
        public void RegisterNewEmployee(User newEmployee);

        //System admin can delete users accounts from the system.
        public void DeleteUser(int userID);

        //system admin can Update UserInformations
        public void UpdateUser(User UpdatedUser); 

        /*
         System admin can reset user’s passwords.
         */
        public void ResetUserPassword(int UserId, string NewPasssword); 

        /*
         System admin must set up the all the lookup data fields, these data fields are : 
         ( Company Buildings, Maintenance Classification, calcellation reason) 
        */
        public void AddBuilding(Building buildingAdded);
        public void AddMaintenanceType(string TypeAr, string TypeEn);
        public void AddCancellationReason(CancellationReason cancellationReasonAdded);

        //system admin can update building 
        public void UpdateBuilding(Building UpdatedBuilding);



    }
}
