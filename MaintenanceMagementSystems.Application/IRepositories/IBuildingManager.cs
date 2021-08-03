using MaintenanceManagementSystem.Database.Models;
using MaintenanceManagementSystem.Entity.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Application.Interfaces
{
    public interface IBuildingManager
    {
        /*
         The Building Manager Can define his buildings and its description like - Not limited to - (Address, No. of floors, Rented/Owned, etc..) 
         can edit and add building details such as: address, No. floors, etc
        */
        public void AddBuilding(Building buliding);
        public bool EditBuilding(int buildingID, int managerID);

        /*
         he can receive the maintenance request (ticket) form the beneficiaries and has the option to either accept it or reject it
         */
        public List<Ticket> ListTickets(int managerID);
        public Ticket GetTicketFor(int requestID);
        public bool ResponseToRequest(RequestResponse response); 
    }
}
