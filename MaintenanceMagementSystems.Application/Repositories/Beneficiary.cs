using MaintenanceManagementSystem.Application.Interfaces;
using MaintenanceManagementSystem.Database.Models;
using MaintenanceManagementSystem.Entity.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Application.Repositories
{
    public class Beneficiary : IBeneficiary
    {
        public bool CancelRequest(RequestResponse response)
        {
            throw new NotImplementedException();
        }

        public bool ConfirmRequest(string state)
        {
            throw new NotImplementedException();
        }

        public Ticket GetRequest(int requestID)
        {
            throw new NotImplementedException();
        }

        public void SubmitRequest(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
