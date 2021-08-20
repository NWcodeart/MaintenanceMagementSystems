using MaintenanceManagementSystem.Database.Lookup;
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

        public Building ViewBuilding();
        public bool EditBuilding(int buildingID, BuildingDto Updatedbuilding);
        public List<TicketDto> ViewTickets();
        public List<Status> ViewTicketsStatus();
        //public Ticket GetTicketFor(int requestID);
        public bool AddComments(string comment, int ticketId);

        public Ticket GetTicket(int ticketId);
    }
}
