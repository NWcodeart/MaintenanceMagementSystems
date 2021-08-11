using MaintenanceManagementSystem.Application.Interfaces;
using MaintenanceManagementSystem.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.BusinessLayer.Repositories
{
    class MaintenanceManager : IMaintenanceManager
    {
        private MaintenanceSysContext _maintenanceSysContext;

        public MaintenanceManager(MaintenanceSysContext maintenanceSysContext)
        {
            _maintenanceSysContext = maintenanceSysContext;
        }

        public bool AssignTeam()
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    List<User> workers = _maintenanceSysContext.Users.Where(u => u.JobTypeId == 3).ToList(); //3 => worker
                    List<Ticket> tickets = _maintenanceSysContext.Tickets.Where(t => t.StatusID == 0).ToList(); // 0 => null

                    return true;


                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RespondToTickets()
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    List<Ticket> tickets = _maintenanceSysContext.Tickets.ToList();

                     return true;
                    
                   
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

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
    }
}
