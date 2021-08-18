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
        public List<Ticket> ViewTickets();
        public List<Ticket> ViewTicketsStatus();
        //public Ticket GetTicketFor(int requestID);
        public bool AddComments(string comment, int ticketId);

        public Ticket GetTicket(int ticketId);
    }
}
