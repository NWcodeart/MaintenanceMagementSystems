using MaintenanceManagementSystem.Application.Interfaces;
using MaintenanceManagementSystem.Database.Lookup;
using MaintenanceManagementSystem.Database.Models;
using MaintenanceManagementSystem.Entity.ModelsDto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.BusinessLayer.Repositories
{
    public class Beneficiary : IBeneficiary
    {
        private MaintenanceSysContext _maintenanceSysContext;
        private IBeneficiaryEntry _beneficiaryEntryRepo;

        public Beneficiary(MaintenanceSysContext maintenanceSysContext, IBeneficiaryEntry beneficiaryEntryRepo)
        {
            _maintenanceSysContext = maintenanceSysContext;
            _beneficiaryEntryRepo = beneficiaryEntryRepo;
        }

        public bool CancelTicket(int requestID, int cancelationReasonID)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    var request = _maintenanceSysContext.Tickets.FirstOrDefault(t => t.BeneficiaryID == _beneficiaryEntryRepo.GetUserId() && t.Id == requestID && t.StatusID == 1); //He can cancel the maintenance request before it reaches the maintenance manager
                    if (request != null)
                    {
                        request.StatusID = 7;
                        request.CancellationReasonID = cancelationReasonID;
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

        public bool ConfirmTicket(int requestID)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    var request = _maintenanceSysContext.Tickets.FirstOrDefault(t => t.BeneficiaryID == _beneficiaryEntryRepo.GetUserId() && t.Id == requestID && t.StatusID == 4); //Only the beneficiary can confirm that the maintenance has been completed
                    if (request != null)
                    {
                        request.StatusID = 5;
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

        public Ticket GetTicket(int requestID)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    var request = _maintenanceSysContext.Tickets.FirstOrDefault(t => t.BeneficiaryID == _beneficiaryEntryRepo.GetUserId() && t.Id == requestID);
                    if(request != null)
                    {
                        return request;
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

        public bool SubmitTicket(TicketRequest ticket)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    var tickets = _maintenanceSysContext.Tickets.Where(t => t.BeneficiaryID == _beneficiaryEntryRepo.GetUserId()).ToList();
                    var isThereActiveTicket = tickets.Exists(t => t.StatusID < 5);
                    if (!isThereActiveTicket)
                    {
                        var newTicket = new Ticket()
                        {
                            BeneficiaryID = _beneficiaryEntryRepo.GetUserId(),
                            StatusID = 1,
                            ApprovalState = 0,
                            Description = ticket.Description,
                            FloorId = ticket.FloorId,
                            MaintenanceTypeID = ticket.MaintenanceTypeID,
                            Date = ticket.Date,
                            Picture = ticket.Picture
                        };
                        _maintenanceSysContext.Add(newTicket);
                        _maintenanceSysContext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public List<Ticket> ListAllTickets()
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    var tickets = _maintenanceSysContext.Tickets.Where(t => t.BeneficiaryID == _beneficiaryEntryRepo.GetUserId()).ToList();
                    return tickets;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<CancellationReason> ListCancellationReasons()
        {
            try
            {
                var cancellationReasons = _maintenanceSysContext.CancelationReasons.ToList();
                return cancellationReasons;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
