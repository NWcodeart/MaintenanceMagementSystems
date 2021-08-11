using MaintenanceManagementSystem.Application.Interfaces;
using MaintenanceManagementSystem.Database.Lookup;
using MaintenanceManagementSystem.Database.Models;
using MaintenanceManagementSystem.Entity.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.BusinessLayer.Repositories
{
    public class MaintenanceWorker : IMaintenanceWorker
    {
        private MaintenanceSysContext _maintenanceSysContext;
        private IBackOfficeEntry _backOfficeEntry;

        public MaintenanceWorker(MaintenanceSysContext maintenanceSysContext, IBackOfficeEntry backOfficeEntry)
        {
            _maintenanceSysContext = maintenanceSysContext;
            _backOfficeEntry = backOfficeEntry;
        }
        public Ticket GetTicket(int TicketId)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    Ticket ticket = _maintenanceSysContext.Tickets.FirstOrDefault(t => t.Id == TicketId);
                    if (ticket != null)
                    {
                        return ticket;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Ticket> ListTickets()
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    List<Ticket> tickets = _maintenanceSysContext.Tickets.SelectMany(t => t.backOfficesTickets).Where(u => u.BackOfficeId == _backOfficeEntry.GetUserId()).Select(t => t.ticket).ToList();
                    if (tickets != null)
                    {
                        return tickets;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AcceptingTicket(int TicketId)
        {
            try
            {
                using (_maintenanceSysContext)
                {

                    bool isAvaliable = ListTickets().Exists(t => !( t.StatusID == 4));
                    if (isAvaliable == true)
                    {
                        var ticket = GetTicket(TicketId);
                        ticket.StatusID = 4;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
