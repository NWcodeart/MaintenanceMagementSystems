using MaintenanceManagementSystem.Database.Models;
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
        public List<Ticket> ListRequests(int workerID);

        public Ticket GetRequest(int requestID, int workerID);

        /*
         Can label the Maintenance request ticket as “Fixing”
         */
        public bool SetStateForRequest(string state);


    }
}
