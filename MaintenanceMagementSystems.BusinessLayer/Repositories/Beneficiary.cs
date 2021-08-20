using MaintenanceManagementSystem.Application.Interfaces;
using MaintenanceManagementSystem.Database.Lookup;
using MaintenanceManagementSystem.Database.Models;
using MaintenanceManagementSystem.Entity.ModelsDto;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
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
        private readonly DbContextOptions<MaintenanceSysContext> _options;

        public Beneficiary(MaintenanceSysContext maintenanceSysContext, 
            IBeneficiaryEntry beneficiaryEntryRepo,
            DbContextOptions<MaintenanceSysContext> options)
        {
            _maintenanceSysContext = maintenanceSysContext;
            _beneficiaryEntryRepo = beneficiaryEntryRepo;
            _options = options;
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
                using (var db = new MaintenanceSysContext(_options))
                {
                    var tickets = db.Tickets.Where(t => t.BeneficiaryID == _beneficiaryEntryRepo.GetUserId()).ToList();
                    var isThereActiveTicket = tickets.Exists(t => t.StatusID < 5);
                    if (!isThereActiveTicket)
                    {
                        var newTicket = new Ticket()
                        {
                            BeneficiaryID = _beneficiaryEntryRepo.GetUserId(),
                            StatusID = 1,
                            ApprovalState = 0,
                            Description = ticket.Description,
                            FloorId = _beneficiaryEntryRepo.getUserFloor(),
                            MaintenanceTypeID = ticket.MaintenanceTypeID,
                            Date = ticket.Date,
                            Picture = ticket.Picture,
                            CreatedBy = _beneficiaryEntryRepo.GetUserId(),
                            CreatedTime = DateTime.Now,
                        };
                        db.Add(newTicket);
                        db.SaveChanges();
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

        public List<TicketDto> ListAllTickets()
        {
            try
            {
                List<TicketDto> Tickets = new List<TicketDto>();
                using (var db = new MaintenanceSysContext(_options))
                {
                    Tickets = db.Tickets.Where(t => t.BeneficiaryID == _beneficiaryEntryRepo.GetUserId()).Select(x => new TicketDto 
                    {
                        Id = x.Id,
                        BeneficiaryID = x.BeneficiaryID,
                        StatusID = x.StatusID,
                        StatusTypeAr = x.status.StatusTypeAr,
                        StatusTypeEn = x.status.StatusTypeEn,
                        Date = x.Date,
                        Picture = x.Picture,
                        MaintenanceTypeID = x.MaintenanceTypeID,
                        MaintenanceTypeNameAr = x.maintenanceType.MaintenanceTypeNameAr,
                        MaintenanceTypeNameEn = x.maintenanceType.MaintenanceTypeNameEn,
                        Description = x.Description,
                        BuildingManagerComment = x.BuildingManagerComment,
                        FloorId = x.FloorId,
                        IsCancelled = x.IsCancelled,
                        CancellationReasonID = x.CancellationReasonID,
                        ReasonTypeAr = x.cancelationReason.ReasonTypeAr,
                        ReasonTypeEn = x.cancelationReason.ReasonTypeEn,
                        RejectedBy = x.RejectedBy,
                        RejectionReason = x.RejectionReason,
                        CreatedBy = x.CreatedBy,
                        CreatedTime = x.CreatedTime,
                        UpdatedBy = x.UpdatedBy,
                        UpdatedTime = x.UpdatedTime,
                        IsDeleted =  x.IsDeleted
                    }).ToList();
                    return Tickets;
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

        public List<MaintenanceType> ListMaintenanceTypes()
        {
            try
            {
                var maintenanceTypes = _maintenanceSysContext.MaintenanceTypes.ToList();
                return maintenanceTypes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UserInfoBeneficiary GetUserInfo()
        {
            UserInfoBeneficiary User = new UserInfoBeneficiary();

            try
            {
                using (_maintenanceSysContext)
                {
                    User = _maintenanceSysContext.Users.Select(x => new UserInfoBeneficiary
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Phone = x.Phone,
                        Email = x.Email,
                        UserRoleId = x.userRole.Id,
                        userRole = x.userRole.RoleNameAr,
                        FloorId = x.FloorId,
                        floorNumber = x.floor.Number,
                        BuildingId = x.building.Id,
                        buildingNumber = x.building.Number,
                        IsDeleted = x.IsDeleted
                    }).Single(x => x.Id == _beneficiaryEntryRepo.GetUserId());
                }
            }
            catch (Exception)
            {
                throw;
            }


            return User;
        }
    }
}
