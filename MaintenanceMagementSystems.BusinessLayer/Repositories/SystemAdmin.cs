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
        private readonly MaintenanceSysContext _maintenanceSysContext;

        public SystemAdmin(MaintenanceSysContext maintenanceSysContext)
        {
            _maintenanceSysContext = maintenanceSysContext;
        }

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
            try
            {
                using (_maintenanceSysContext)
                {
                    _maintenanceSysContext.CancelationReasons.Add(cancellationReasonAdded);
                    _maintenanceSysContext.SaveChanges();
                }
            } catch (Exception) 
            {
                throw;
            }
        }
        public void AddCancellationReason(string reasonAr, string reasonEn)
        {
            var vewReason = new CancellationReason() { ReasonTypeAr = reasonAr, ReasonTypeEn = reasonEn };
            try
            {
                using (_maintenanceSysContext)
                {
                    _maintenanceSysContext.CancelationReasons.Add(vewReason);
                    _maintenanceSysContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AddMaintenanceType(string TypeAr , string TypeEn)
        {
            var newType = new MaintenanceType() { MaintenanceTypeNameAr = TypeAr, MaintenanceTypeNameEn = TypeEn };
            try
            {
                using (_maintenanceSysContext)
                {
                    _maintenanceSysContext.MaintenanceTypes.Add(newType);
                    _maintenanceSysContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //user Section
        public void DeleteUser(int userDeleted)
        {
            User UserToDelete = _maintenanceSysContext.Users
                            .Where(b => b.Id == userDeleted)
                            .FirstOrDefault();

            try
            {
                if (UserToDelete != null)
                {
                    UserToDelete.IsDeleted = true;

                    _maintenanceSysContext.Update(UserToDelete);
                    _maintenanceSysContext.SaveChanges();
                }

            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public void RegisterNewEmployee(User newEmployee)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    var newUser = new User()
                    {
                        UserRoleId = newEmployee.UserRoleId, 
                        Name = newEmployee.Name,
                        Email = newEmployee.Email,
                        Phone = newEmployee.Phone,
                        FloorId = newEmployee.FloorId,
                        IsForgetPassword = true //true if user click on foreget pass or when admin who add the user
                    };

                    newUser.Password = BCrypt.Net.BCrypt.HashPassword(newEmployee.Password);

                    if(newUser.UserRoleId == 3)
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

        public void ResetUserPassword(int UserId, string NewPasssword)
        {
            try
            {
                User UserPassToUpdate = _maintenanceSysContext.Users.Single(u => u.Id == UserId);
                UserPassToUpdate.Password = BCrypt.Net.BCrypt.HashPassword(NewPasssword);
                _maintenanceSysContext.Users.Update(UserPassToUpdate);
                _maintenanceSysContext.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }

        }

        public void UpdateUser(User UpdatedUser)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    User UserToUpdate = _maintenanceSysContext.Users
                            .Where(b => b.Id == UpdatedUser.Id)
                            .FirstOrDefault();
                    if (UserToUpdate != null)
                    {
                        _maintenanceSysContext.Entry(UserToUpdate).CurrentValues.SetValues(UpdatedUser);
                    }
                    _maintenanceSysContext.SaveChanges();

                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
