﻿using MaintenanceManagementSystem.Database.Lookup;
using MaintenanceManagementSystem.Database.Models;
using MaintenanceManagementSystem.Entity.ModelsDto;
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


        //MaintenanceType
        public void AddMaintenanceType(MaintenanceType maintenanceType);
        public void DeleteMaintenanceType(int id);

        //CancellationReason
        public void AddCancellationReason(CancellationReason cancellationReasonAdded);
        public void DeleteCancellationReason(int id);

        //building 
        public void UpdateBuilding(Building UpdatedBuilding);
        public List<BuildingsTable> GetBuildings();
        public void DeleteBuilding(int id);
        public void AddBuilding(Building buildingAdded);

    }
}
