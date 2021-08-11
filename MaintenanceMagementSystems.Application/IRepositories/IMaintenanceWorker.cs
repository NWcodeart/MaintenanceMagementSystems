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
    public interface IMaintenanceWorker
    {
        //workers: can only access tickets assigned to him

        /*
         He receives the maintenance request from the maintenance manager and can 
         only accept it if he is free and not assigned to another request.
         */
        public List<Ticket> ListTickets(int workerID);

        public Ticket GetTicket(int requestID);

        /*
         Can label the Maintenance request ticket as “Fixing”
         */
        public bool AcceptingTicket(int TicketId, int WorkerId);

        //for view purpose so we can list the status in drop down list
        
    }
}
