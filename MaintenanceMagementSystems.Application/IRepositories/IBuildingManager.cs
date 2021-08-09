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

        public Building ViewBuilding(int managerID);
        public bool EditBuilding(int buildingID, BuildingDto Updatedbuilding);
        public List<Ticket> ViewTickets(int managerID);
        public List<Ticket> ViewTicketsStatus(int managerID);
        //public Ticket GetTicketFor(int requestID);
        public bool AddComments(TicketDto ticket); 
    }
}
