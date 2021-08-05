using MaintenanceManagementSystem.Application.Interfaces;
using MaintenanceManagementSystem.Database.ManyToMany;
using MaintenanceManagementSystem.Database.Models;
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

        public BuildingManager(MaintenanceSysContext maintenanceSysContext)
        {
            _maintenanceSysContext = maintenanceSysContext;
        }

        public bool AddComments(int ticketId, string comment)
        {
            try
            {
                using (_maintenanceSysContext)
                {                    
                    Ticket ticket = _maintenanceSysContext.Tickets.FirstOrDefault(t => t.Id == ticketId);
                    if (ticket != null)
                    {
                        ticket.BuildingManagerComment = comment;
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

        public bool EditBuilding(int buildingID, Building Updatedbuilding)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                                                                                                                   //login claims
                    Building building = _maintenanceSysContext.Buildings.FirstOrDefault(b => b.Id == buildingID //&& b.builbigManager
                    );
                    if (building != null)
                    {
                        building.floors = Updatedbuilding.floors;
                        building.IsOwned = Updatedbuilding.IsOwned;
                        building.CityId = Updatedbuilding.CityId;
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


        public Building ViewBuilding(int managerID)
        {
            try
            {
                using (_maintenanceSysContext)
                {

                    Building building = _maintenanceSysContext.Buildings.FirstOrDefault(b => b.BuildingManager == managerID);
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

        public List<Ticket> ViewTickets(int managerID)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    
                    List<Ticket> tickets = _maintenanceSysContext.Tickets.Where(u => u.Id == managerID).Include(t => t.backOfficesTickets).ToList();
                    List<User> user = _maintenanceSysContext.Users.Where(u => u.Id == managerID).Include(t => t.BackOfficeTickets).ToList();
       
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


        public List<Ticket> ViewTicketsStatus(int managerID)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    //same the above one with adding select clause
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
