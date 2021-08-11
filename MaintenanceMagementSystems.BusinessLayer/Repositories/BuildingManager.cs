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
        private IBackOfficeEntry _backOfficeEntry ;
        public BuildingManager(MaintenanceSysContext maintenanceSysContext, IBackOfficeEntry backOfficeEntry)
        {
            _maintenanceSysContext = maintenanceSysContext;
            _backOfficeEntry = backOfficeEntry;
        }

        public bool AddComments(int TicketId, string comment)
        {
            try
            {
                using (_maintenanceSysContext)
                {                    
                    Ticket ticketObject = _maintenanceSysContext.Tickets.FirstOrDefault(t => t.Id == TicketId);
                    if (ticketObject != null)
                    {
                        ticketObject.BuildingManagerComment = comment;
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

        public List<Ticket> ViewTickets()
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    List<Ticket> tickets = null;
                    List<int> ticketsId = _maintenanceSysContext.Tickets.SelectMany(t => t.backOfficesTickets).Where(u => u.BackOfficeId == _backOfficeEntry.GetUserId()).Select(t => t.TicketId).ToList();
                  
                     foreach( var i in ticketsId)
                    {
                        tickets = _maintenanceSysContext.Tickets.Where(t => t.Id == i).ToList();
                    }

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


        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------


        public List<Ticket> ViewTicketsStatus()
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
