using MaintenanceManagementSystem.Application.Interfaces;
using MaintenanceManagementSystem.Database.ManyToMany;
using MaintenanceManagementSystem.Database.Models;
using MaintenanceManagementSystem.Entity.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.BusinessLayer.Repositories
{
    public class MaintenanceManager : IMaintenanceManager
    {
        private MaintenanceSysContext _maintenanceSysContext;
        private IBackOfficeEntry _backOfficeEntry;

        public MaintenanceManager(MaintenanceSysContext maintenanceSysContext, IBackOfficeEntry backOfficeEntry)
        {
            _maintenanceSysContext = maintenanceSysContext;
            _backOfficeEntry = backOfficeEntry;

        }

        public List<User> ListOfWorkers(int TicketId)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    Ticket ticket = _maintenanceSysContext.Tickets.FirstOrDefault(t => t.Id == TicketId);
                    List <User> workers = _maintenanceSysContext.Users.Where(u => u.UserRoleId == 4 && u.MaintenanceTypeId == ticket.MaintenanceTypeID).ToList(); //4 => worker
                    if (workers != null)
                    {
                        return workers;
                    }
                    return null;
                    
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------


        public List<Ticket> ListNewTickets()
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    List<Ticket> tickets = _maintenanceSysContext.Tickets.Where(t => t.StatusID == 1).ToList(); // 1 => new
                    if (tickets != null)
                    {
                        return tickets;
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------



        public Ticket GetTicket(int TicketId)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    Ticket ticket = _maintenanceSysContext.Tickets.Where(t => t.Id == TicketId).FirstOrDefault();
                    if(ticket != null)
                    {
                        return ticket;
                    }
                        return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------


        public User GetWorker(int WorkerId, int TicketId)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    User worker = _maintenanceSysContext.Users.Where(t => t.Id == WorkerId).FirstOrDefault();
                    if (worker != null)
                    {
                        BackOfficesTickets record = new BackOfficesTickets();
                        record.TicketId = TicketId;
                        record.BackOfficeId = worker.Id ;
                        return worker;
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------


        public bool RespondToTicket(int TicketId, TicketRespond respond)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    Ticket ticket = GetTicket(TicketId);
                    if (ticket != null)
                    {
                        if(ticket.status == null)
                        {
                            ticket.StatusID = respond.status;
                            if(respond.status == 6)
                            {
                                ticket.RejectedBy = _backOfficeEntry.GetUserId();///Login cliams 
                                ticket.RejectionReason = respond.reason;
                            }
                        }
                        _maintenanceSysContext.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------


        public List<Ticket> ViewTickets()
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    List<Ticket> tickets = _maintenanceSysContext.Tickets.ToList();
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

        public List<Ticket> ViewUnderReviewTickets()
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    List<Ticket> tickets = _maintenanceSysContext.Tickets
                        .Where(t => t.StatusID == 2 || ((t.CreatedTime - DateTime.Now).TotalDays >= 2) && t.StatusID == 1).ToList(); //2 => under review -> has been passed to BM OR 1=> has not passed to BM and it has been created from more than 2 days
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
    }
}
