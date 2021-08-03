using MaintenanceManagementSystem.Database.Models;
using MaintenanceManagementSystem.Entity.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Application.Interfaces
{
    public interface IBeneficiary
    {
        //beneficiary can only access tickets opened by him.

        /*
         he can submit a maintenance request ticket though the beneficiary portal.
         */
        public void SubmitRequest(Ticket ticket);

        /*
         Only the beneficiary can confirm that the maintenance has been completed 
         */
        public bool ConfirmRequest(string state);

        /*
         he can cancel the maintenance request before it reaches the maintenance 
         manager after that it cannot be closed. also he should provide reason of 
         cancellation
         */
        public bool CancelRequest(RequestResponse response); 

        /*
         must sign of the repair order after the work has been made
         */
        public Ticket GetRequest(int requestID);


    }
}
