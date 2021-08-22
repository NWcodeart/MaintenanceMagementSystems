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
    public class BuildingManager : IBuildingManager
    {
        private MaintenanceSysContext _maintenanceSysContext;
        private IBackOfficeEntry _backOfficeEntry;
        private readonly DbContextOptions<MaintenanceSysContext> _options;
        public BuildingManager(MaintenanceSysContext maintenanceSysContext, IBackOfficeEntry backOfficeEntry, DbContextOptions<MaintenanceSysContext> options)
        {
            _maintenanceSysContext = maintenanceSysContext;
            _backOfficeEntry = backOfficeEntry;
            _options = options;
        }

        public bool AddComments(Comment comment)
        {
            try
            {
                using (_maintenanceSysContext)
                {                    
                    Ticket ticket = _maintenanceSysContext.Tickets.FirstOrDefault(t => t.StatusID == 1 && t.Id == comment.id);  //1 => new

                    if (ticket != null)
                    {
                           ticket.BuildingManagerComment = comment.comment;
                           ticket.StatusID = 2; //2 => under review
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

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public bool EditBuilding(int buildingID, BuildingDto Updatedbuilding)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                                                                                                                   //login claims
                    Building building = _maintenanceSysContext.Buildings.FirstOrDefault(b => b.Id == buildingID && b.BuildingManagerId == _backOfficeEntry.GetUserId());
                    if (building != null)
                    {
                        building.floors = (ICollection<Floor>)Updatedbuilding.floors;
                        building.IsOwned = Updatedbuilding.IsOwned;
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


        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public Building ViewBuilding()
        {
            try
            {
                using (_maintenanceSysContext)
                {

                    Building building = _maintenanceSysContext.Buildings.FirstOrDefault(b => b.BuildingManagerId == _backOfficeEntry.GetUserId());
                    if (building != null)
                    {
                        return building;
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

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public List<TicketDto> ViewTickets()
        {
            try
            {
                using (var db = new MaintenanceSysContext(_options))
                {

                    List<TicketDto> TicketsDto = new List<TicketDto>();
                    //List<Ticket> tickets = new List<Ticket>();
                    List<int> ticketsId = db.Tickets.SelectMany(t => t.backOfficesTickets).Where(u => u.BackOfficeId == _backOfficeEntry.GetUserId()).Select(t => t.TicketId).ToList();
                  
                     foreach( var i in ticketsId)
                    {
                        TicketDto x = db.Tickets.Select(x => new TicketDto
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
                        }).Single(t => t.Id == i);
                        TicketsDto.Add(x);
                    }

                    if (TicketsDto != null)
                    {
                        return TicketsDto;
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


        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------

        public Ticket GetTicket(int ticketId)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    Ticket ticket = null;
                    List<int> ticketsId = _maintenanceSysContext.Tickets.SelectMany(t => t.backOfficesTickets).Where(u => u.BackOfficeId == _backOfficeEntry.GetUserId()).Select(t => t.TicketId).ToList();

                    foreach (var i in ticketsId)
                    {
                        if(i == ticketId)
                        {
                             ticket = _maintenanceSysContext.Tickets.Where(t => t.Id == i).FirstOrDefault();

                        }
                    }

                    if (ticket != null)
                    {
                        return ticket;
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

        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public List<Status> ViewTicketsStatus()
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    List<Status> ticketsStatus = null;
                    List<int> ticketsId = _maintenanceSysContext.Tickets.SelectMany(t => t.backOfficesTickets).Where(u => u.BackOfficeId == _backOfficeEntry.GetUserId()).Select(t => t.TicketId).ToList();

                    foreach (var i in ticketsId)
                    {
                        ticketsStatus = _maintenanceSysContext.Tickets.Where(t => t.Id == i).Select(t =>t.status).ToList();
                        return ticketsStatus;
                    }
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
