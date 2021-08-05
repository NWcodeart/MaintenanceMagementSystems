using MaintenanceManagementSystem.Application.Interfaces;
using MaintenanceManagementSystem.Database.Lookup;
using MaintenanceManagementSystem.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.BusinessLayer.Repositories
{
    class SystemAdmin : ISystemAdmin
    {
        private MaintenanceSysContext _maintenanceSysContext;

        //bulding section
        public void AddBuilding(Building buildingAdded)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    var newBuilding = new Building()
                    {
                        Number = buildingAdded.Number,
                        IsOwned = buildingAdded.IsOwned,
                        CityId = buildingAdded.CityId,
                        Street = buildingAdded.Street,
                        BuildingManagerId = buildingAdded.BuildingManagerId
                    };
                    _maintenanceSysContext.Buildings.Add(newBuilding);
                    _maintenanceSysContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateBuilding(Building UpdatedBuilding)
        {
            try
            {
                var allBuilding = _maintenanceSysContext.Buildings;
                using (_maintenanceSysContext)
                {
                    Building BuildingToUpdate = _maintenanceSysContext.Buildings
                            .Where(b => b.Id == UpdatedBuilding.Id)
                            .FirstOrDefault();
                    if (BuildingToUpdate != null)
                    {
                        _maintenanceSysContext.Entry(BuildingToUpdate).CurrentValues.SetValues(UpdatedBuilding);
                    }
                    _maintenanceSysContext.SaveChanges();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //dropdown List
        public void AddCancellationReason(CancellationReason cancellationReasonAdded)
        {
            throw new NotImplementedException();
        }

        public void AddMaintenanceType(MaintenanceType maintenanceTypeAdded)
        {
            throw new NotImplementedException();
        }

        //user Section
        public void DeleteUser(int userID)
        {
            throw new NotImplementedException();
        }

        public void RegisterNewEmployee(User newEmployee)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    var newUser = new User()
                    {
                        UserRoleId = 2, //2 means BackOffic
                        Name = newEmployee.Name,
                        Email = newEmployee.Email,
                        Phone = newEmployee.Phone,
                        JobTypeId = newEmployee.JobTypeId, // 1 = Building manager, 2 = Maintenance Manager, 3 = Maintenance worker
                        FloorId = newEmployee.FloorId,
                        IsForgetPassword = true //true if user click on foreget pass or when admin who add the user
                    };

                    newUser.Password = BCrypt.Net.BCrypt.HashPassword(newEmployee.Password);

                    if(newUser.JobTypeId == 3)
                    {
                        newUser.maintenanceType = newEmployee.maintenanceType;
                    }

                    _maintenanceSysContext.Users.Add(newUser);
                    _maintenanceSysContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ResetUserPassword(User user)
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(User UpdatedUser)
        {
            throw new NotImplementedException();
        }
    }
}
