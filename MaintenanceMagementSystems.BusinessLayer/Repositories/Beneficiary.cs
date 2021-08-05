using MaintenanceManagementSystem.Application.Interfaces;
using MaintenanceManagementSystem.Database.Models;
using MaintenanceManagementSystem.Entity.ModelsDto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Application.Repositories
{
    public class Beneficiary : IBeneficiary
    {
        private MaintenanceSysContext _maintenanceSysContext;

        public Beneficiary(MaintenanceSysContext maintenanceSysContext)
        {
            _maintenanceSysContext = maintenanceSysContext;
        }

        public bool CancelTicket(int beneficiaryID, int requestID)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    var request = GetTicket(beneficiaryID, requestID);
                    var canceledStatus = _maintenanceSysContext.Statuses.FirstOrDefault(s => s.Id == 7);
                    if (request != null)
                    {
                        request.status = canceledStatus;
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

        public bool ConfirmTicket(int beneficiaryID, int requestID) //to be reviwed
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    var request = GetTicket(beneficiaryID, requestID);
                    var completedStatus = _maintenanceSysContext.Statuses.FirstOrDefault(s => s.Id == 5);
                    if (request != null)
                    {
                        request.status = completedStatus;
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

        public Ticket GetTicket(int beneficiaryID, int requestID)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    var request = _maintenanceSysContext.Tickets.FirstOrDefault(t => t.BeneficiaryID == beneficiaryID && t.Id == requestID);
                    return request;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void SubmitTicket(int beneficiaryID, Ticket ticket)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    _maintenanceSysContext.Add(ticket);
                    _maintenanceSysContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<Ticket> ListAllTickets(int beneficiaryID)
        {
            throw new NotImplementedException();
        }

        public List<Ticket> ListTicketsHistory(int beneficiaryID)
        {
            throw new NotImplementedException();
        }
    }
}
