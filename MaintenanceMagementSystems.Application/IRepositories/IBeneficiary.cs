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
    public interface IBeneficiary
    {
        /*
         beneficiary can only access tickets opened by him.
        */
        public List<TicketDto> ListAllTickets();

        /*
         he can submit a maintenance request ticket though the beneficiary portal.
         */
        public bool SubmitTicket(TicketRequest ticket);

        /*
         Only the beneficiary can confirm that the maintenance has been completed 
         */
        public bool ConfirmTicket(int requestID);

        /*
         he can cancel the maintenance request before it reaches the maintenance 
         manager after that it cannot be closed. also he should provide reason of 
         cancellation
         */
        public bool CancelTicket(int requestID, int cancelationReasonID);

        /*
         for view purpose, so we can render the cancelation reasons as a drop-down list
         */
        public List<CancellationReason> ListCancellationReasons();

        /*
         must sign of the repair order after the work has been made
         */
        public Ticket GetTicket(int requestID);

        /*
         for view purpose, so we can render the maintenance types as a drop-down list
         */
        public List<MaintenanceType> ListMaintenanceTypes();

        //User Accouent
        public UserInfoBeneficiary GetUserInfo();
    }
}
