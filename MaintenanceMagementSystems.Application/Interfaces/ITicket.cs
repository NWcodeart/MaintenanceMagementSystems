using MaintenanceManagementSystem.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Application.Interfaces
{
    public interface ITicket
    {
        public bool AddTicket(Ticket ticket);
        public bool SetStatus(Ticket ticket);
        public Ticket GetTicket(int Ticketid);
        public List<Ticket> ViewTicketsForAdmin(int BackOfficeId);
        public List<Ticket> ViewTicketsForMaintenanceManager(int BackOfficeId);
        public List<Ticket> ViewTicketsForBuildingManager(int BackOfficeId);

    }
}
