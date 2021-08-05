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
        /*
         beneficiary can only access tickets opened by him.
        */
        public List<Ticket> ListAllTickets(int beneficiaryID);

        public List<Ticket> ListTicketsHistory(int beneficiaryID);

        /*
         he can submit a maintenance request ticket though the beneficiary portal.
         */
        public void SubmitTicket(int beneficiaryID, Ticket ticket);

        /*
         Only the beneficiary can confirm that the maintenance has been completed 
         */
        public bool ConfirmTicket(int beneficiaryID, int requestID);

        /*
         he can cancel the maintenance request before it reaches the maintenance 
         manager after that it cannot be closed. also he should provide reason of 
         cancellation
         */
        public bool CancelTicket(int beneficiaryID, int requestID); 

        /*
         must sign of the repair order after the work has been made
         */
        public Ticket GetTicket(int beneficiaryID, int requestID);
    }
}
