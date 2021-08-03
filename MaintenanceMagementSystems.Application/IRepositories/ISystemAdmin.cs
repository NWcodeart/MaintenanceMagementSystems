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
        public bool EmployeeRegistration(User newEmployee); 

        /*
         System admin can reset user’s passwords.
         */
        public bool ResetUserPassword(User user); 

        /*
         System admin must set up the all the lookup data fields, these data fields are : 
         ( Company Buildings, Maintenance Team and Maintenance Classification Hierarchy) 
         (Not Sure) 
        */
        public void AddBuilding(Building building);
        public void AddMaintenanceType(MaintenanceType maintenanceType);

        /*
         System admin can delete users accounts from the system.
         */
        public void DeleteUser(int userID); 

        /*
         System admin has the ability to close maintenance request 
         */
        public bool CloseRequest(int requestID); 

        /*
         System admin can access all tickets and view all of details related to it.
         */
        public List<Ticket> ViewTickets();
        public Ticket GetTicket(int ticketID);
    }
}
