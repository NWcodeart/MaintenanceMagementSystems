using MaintenanceManagementSystem.Application.Interfaces;
using MaintenanceManagementSystem.Database.Lookup;
using MaintenanceManagementSystem.Database.ManyToMany;
using MaintenanceManagementSystem.Database.Models;
using MaintenanceManagementSystem.Entity.ModelsDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.BusinessLayer.Repositories
{
    public class MaintenanceManager : IMaintenanceManager
    {
        private MaintenanceSysContext _maintenanceSysContext;
        private IBackOfficeEntry _backOfficeEntry;

        public MaintenanceManager(MaintenanceSysContext maintenanceSysContext, IBackOfficeEntry backOfficeEntry)
        {
            _maintenanceSysContext = maintenanceSysContext;
            _backOfficeEntry = backOfficeEntry;

        }

        public List<User> ListOfWorkers(int TicketId)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    Ticket ticket = _maintenanceSysContext.Tickets.FirstOrDefault(t => t.Id == TicketId);
                    List <User> workers = _maintenanceSysContext.Users.Where(u => u.UserRoleId == 4 && u.MaintenanceTypeId == ticket.MaintenanceTypeID).ToList(); //4 => worker
                    if (workers != null)
                    {
                        return workers;
                    }
                    return null;
                    
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------


        public List<Ticket> ListNewTickets()
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    List<Ticket> tickets = _maintenanceSysContext.Tickets.Where(t => t.StatusID == 1).ToList(); // 1 => new
                    if (tickets != null)
                    {
                        return tickets;
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------



        public Ticket GetTicket(int TicketId)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    Ticket ticket = _maintenanceSysContext.Tickets.Where(t => t.Id == TicketId).FirstOrDefault();
                    if(ticket != null)
                    {
                        return ticket;
                    }
                        return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------


        public User GetWorker(int WorkerId, int TicketId)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    User worker = _maintenanceSysContext.Users.Where(t => t.Id == WorkerId).FirstOrDefault();
                    if (worker != null)
                    {
                        BackOfficesTickets record = new BackOfficesTickets();
                        record.TicketId = TicketId;
                        record.BackOfficeId = worker.Id ;
                        return worker;
                    }
                    return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------


        public bool RespondToTicket(int TicketId, TicketRespond respond)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    Ticket ticket = GetTicket(TicketId);
                    if (ticket != null)
                    {
                        if(ticket.status == null)
                        {
                            ticket.StatusID = respond.status;
                            if(respond.status == 6)
                            {
                                ticket.RejectedBy = _backOfficeEntry.GetUserId();///Login cliams 
                                ticket.RejectionReason = respond.reason;
                            }
                        }
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


        //-------------------------------------------------------------------------------------------------------------------------------------------------------------


        public List<TicketDto> ViewTickets()
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    List<TicketDto> tickets = _maintenanceSysContext.Tickets.Select(x => new TicketDto
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
                        IsDeleted = x.IsDeleted
                    }).ToList();
                    if (tickets != null)
                    {
                        return tickets;
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
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------
        public List<TicketDto> ViewUnderReviewTickets()
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    List<TicketDto> UnderReviewTickets = _maintenanceSysContext.Tickets
                        .Select(x => new TicketDto
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
                            IsDeleted = x.IsDeleted
                        }).Where(t => t.StatusID == 2).ToList(); //2 => under review -> has been passed to BM OR 1=> has not passed to BM and it has been created from more than 2 days

                    List<TicketDto> PassedTwoDaysTickets = _maintenanceSysContext.Tickets
                        .Select(x => new TicketDto
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
                            IsDeleted = x.IsDeleted
                        }).Where(t => (t.CreatedTime - DateTime.Now).TotalDays >= 2 && t.StatusID == 1).ToList();

                    foreach(var i in UnderReviewTickets)
                    {
                        PassedTwoDaysTickets.Add(i);
                    }
                    if (PassedTwoDaysTickets != null )
                    {
                        return PassedTwoDaysTickets;
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

        //-------------------------------------------------------------------------------------------------------------------------------------------------------------
        public bool AddMainteneceType(MaintenanceType NewType)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    MaintenanceType type = new MaintenanceType();
                    type.Id = NewType.Id;
                    type.MaintenanceTypeNameAr = NewType.MaintenanceTypeNameAr;
                    type.MaintenanceTypeNameAr = NewType.MaintenanceTypeNameEn;
                    _maintenanceSysContext.MaintenanceTypes.Add(type);
                    _maintenanceSysContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------
        public bool UpdateMainteneceType(MaintenanceType UpdatedType)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    MaintenanceType type = _maintenanceSysContext.MaintenanceTypes.FirstOrDefault(t => t.Id == UpdatedType.Id);
                    if (type != null)
                    {
                        type.Id = UpdatedType.Id;
                        type.MaintenanceTypeNameAr = UpdatedType.MaintenanceTypeNameAr;
                        type.MaintenanceTypeNameAr = UpdatedType.MaintenanceTypeNameEn;
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
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------
        public bool DeleteMainteneceType(MaintenanceType DeletedType)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    MaintenanceType type = _maintenanceSysContext.MaintenanceTypes.FirstOrDefault(t => t.Id == DeletedType.Id);
                    if(type != null)
                    {
                        _maintenanceSysContext.MaintenanceTypes.Remove(type);
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
        //-------------------------------------------------------------------------------------------------------------------------------------------------------------
        public List<MaintenanceType> ViewMainteneceType()
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    List<MaintenanceType> types = _maintenanceSysContext.MaintenanceTypes.ToList();
                    if (types != null)
                    {
                        return types;
                    }
                    else
                        return null;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
