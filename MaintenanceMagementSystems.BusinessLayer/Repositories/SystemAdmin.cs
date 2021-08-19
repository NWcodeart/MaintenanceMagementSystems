using MaintenanceManagementSystem.Application.Interfaces;
using MaintenanceManagementSystem.Database.Lookup;
using MaintenanceManagementSystem.Database.Models;
using MaintenanceManagementSystem.Entity.LookupDto;
using MaintenanceManagementSystem.Entity.ModelsDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.BusinessLayer.Repositories
{
    public class SystemAdmin : ISystemAdmin
    {
        private readonly MaintenanceSysContext _maintenanceSysContext;

        private readonly DbContextOptions<MaintenanceSysContext> _options;
        public SystemAdmin(MaintenanceSysContext maintenanceSysContext, DbContextOptions<MaintenanceSysContext> options)
        {
            _maintenanceSysContext = maintenanceSysContext;
            _options = options;
        }

        //bulding section
        public void AddBuilding(BuildingAdd buildingAdded)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    var newBuilding = new Building()
                    {
                        Number = buildingAdded.BuildingNumber,
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

        public void RegisterNewEmployee(BackOfficeRegistration newEmployee)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    var newUser = new User()
                    {  
                        Name = newEmployee.Name,
                        Email = newEmployee.Email,
                        UserRoleId = newEmployee.UserRoleId,
                        Phone = newEmployee.Phone,
                        buildingId = newEmployee.BuildingNumber,
                        FloorId = newEmployee.FloorNumber,
                        IsForgetPassword = true //true if user click on foreget pass or when admin who add the user
                    };

                    newUser.Password = BCrypt.Net.BCrypt.HashPassword(newEmployee.Password);

                    if(newUser.UserRoleId == 3)
                    {
                        newUser.MaintenanceTypeId = newEmployee.MaintenanceTypeId;
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
        public List<BuildingsTable> GetBuildings()
        {
            var BuildingsTable = new List<BuildingsTable>();
            using (_maintenanceSysContext)
            {
                BuildingsTable = _maintenanceSysContext.Buildings.Select(b => new BuildingsTable
                {
                    BuildingId = b.Id,
                    BuildingNumber = b.Number,
                    FloorTables = b.floors.Select(f => new FloorTable
                    {
                        FloorId = f.Id,
                        FloorNumber = f.Number
                    }).ToList(),
                    CountryId = b.city.CountryId,
                    Country = b.city.country.CountryNameAr,
                    CityId = b.CityId,
                    City = b.city.CityNameAr,
                    Street = b.Street,
                    BuildingManagerId = b.BuildingManagerId,
                    BuildingManagerName = b.UserbuildingManager.Name,
                    BuildingManagerEmail = b.UserbuildingManager.Email,
                    IsOwned = b.IsOwned
                }).ToList();
            }
            return BuildingsTable;

        }

        public void DeleteBuilding(int id)
        {
            Building buildingToDelete = _maintenanceSysContext.Buildings.FirstOrDefault(b => b.Id == id);

            if(buildingToDelete != null)
            {
                _maintenanceSysContext.Remove(buildingToDelete);
                _maintenanceSysContext.SaveChanges();
            }
        }

        public void DeleteMaintenanceType(int id)
        {
            MaintenanceType maintenanceType = _maintenanceSysContext.MaintenanceTypes.FirstOrDefault(m => m.Id == id);
            _maintenanceSysContext.Remove(maintenanceType);
            _maintenanceSysContext.SaveChanges();
        }

        public void DeleteCancellationReason(int id)
        {
            CancellationReason cancellationReason = _maintenanceSysContext.CancelationReasons.FirstOrDefault(m => m.Id == id);
            _maintenanceSysContext.Remove(cancellationReason);
            _maintenanceSysContext.SaveChanges();
        }

        public List<MaintenanceType> GetAllMaintenanceType()
        {
            return _maintenanceSysContext.MaintenanceTypes.ToList();
        }

        public List<CancellationReason> GetCancellationReason()
        {
            return _maintenanceSysContext.CancelationReasons.ToList();
        }

        public List<User> GetUsers()
        {
            return _maintenanceSysContext.Users.ToList();
        }

        public List<CountryDto> GetCountries()
        {
            List<CountryDto> Countries = new List<CountryDto>();
            using (var db = new MaintenanceSysContext(_options))
            {
                Countries = db.Countries.Select(c => new CountryDto
                {
                    Id = c.Id,
                    CountryNameAr = c.CountryNameAr,
                    CountryNameEn = c.CountryNameEn,
                    Cities = c.Cities.Select(x => new CityDto
                    {
                        Id = x.Id,
                        CityNameAr = x.CityNameAr,
                        CityNameEn = x.CityNameEn
                    }).ToList()
                }).ToList();
            }
            return Countries;
        }

        public void DeleteCountry(int id)
        {
            Country country = _maintenanceSysContext.Countries.FirstOrDefault(m => m.Id == id);
            _maintenanceSysContext.Remove(country);
            _maintenanceSysContext.SaveChanges();
        }

        public void AddCountry(Country country)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    _maintenanceSysContext.Countries.Add(country);
                    _maintenanceSysContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteCity(int id)
        {
            City city = _maintenanceSysContext.Cities.FirstOrDefault(m => m.Id == id);
            _maintenanceSysContext.Remove(city);
            _maintenanceSysContext.SaveChanges();
        }

        public void AddCity(City city)
        {
            try
            {
                using (_maintenanceSysContext)
                {
                    _maintenanceSysContext.Cities.Add(city);
                    _maintenanceSysContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool CheckExistence(string email)
        {
            try
            {
                var user = _maintenanceSysContext.Users.FirstOrDefault(u => u.Email == email);
                if (user != null)
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
