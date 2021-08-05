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
        public void Register(BeneficiaryRegistration user);

        public bool CheckExistence(string email); //for regesriation

        public User AuthenticateUser(Login Login);

        public int GetUserId();

        public string GetUserRole();

        public bool ForgetPassword(string email);

        public void ChangeLanguage(); //?????????????????

        //beneficiary can only access tickets opened by him.

        /*
         he can submit a maintenance request ticket though the beneficiary portal.
         */
        public void SubmitRequest(int beneficiaryID, Ticket ticket);

        /*
         Only the beneficiary can confirm that the maintenance has been completed 
         */
        public bool ConfirmRequest(int beneficiaryID, int requestID);

        /*
         he can cancel the maintenance request before it reaches the maintenance 
         manager after that it cannot be closed. also he should provide reason of 
         cancellation
         */
        public bool CancelRequest(int beneficiaryID, int requestID); 

        /*
         must sign of the repair order after the work has been made
         */
        public Ticket GetRequest(int beneficiaryID, int requestID);
    }
}
