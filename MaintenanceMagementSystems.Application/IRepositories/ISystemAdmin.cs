using MaintenanceManagementSystem.Database.Lookup;
using MaintenanceManagementSystem.Database.Models;
using MaintenanceManagementSystem.Entity.LookupDto;
using MaintenanceManagementSystem.Entity.ModelsDto;
using System.Collections.Generic;

namespace MaintenanceManagementSystem.Application.Interfaces
{
    public interface ISystemAdmin
    {
        /*
         System admin will register the employees and assign them their roles and privileges (Building Manager, Maintenance Manager and Maintenance Worker)
         */
        public void RegisterNewEmployee(BackOfficeRegistration newEmployee);
        public bool CheckExistence(string email);

        //System admin can delete users accounts from the system.
        public void DeleteUser(int userID);

        //system admin can Update UserInformations
        public void UpdateUser(UserInfoBeneficiary UpdatedUser);
        public List<User> GetUsers();
        /*
         System admin can reset user’s passwords.
         */
        public void ResetUserPassword(int UserId, string NewPasssword);


        //MaintenanceType
        public void AddMaintenanceType(string TypeAr, string TypeEn);
        public void DeleteMaintenanceType(int id);
        public List<MaintenanceType> GetAllMaintenanceType();

        //CancellationReason
        public void AddCancellationReason(CancellationReason cancellationReasonAdded);
        public void DeleteCancellationReason(int id);
        public List<CancellationReason> GetCancellationReason();

        //building 
        public void UpdateBuilding(Building UpdatedBuilding);
        public List<BuildingsTable> GetBuildings();
        public void DeleteBuilding(int id);
        public void AddBuilding(BuildingAdd buildingAdded);

        //ccountry
        public List<CountryDto> GetCountries();
        public void DeleteCountry(int id);
        public void AddCountry(Country country);

        //city
        public void DeleteCity(int id);
        public void AddCity(City city);
    }
}
