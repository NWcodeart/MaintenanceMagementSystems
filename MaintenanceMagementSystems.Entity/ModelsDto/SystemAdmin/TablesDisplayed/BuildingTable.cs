using MaintenanceManagementSystem.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Entity.ModelsDto.SystemAdmin.TablesDisplayed
{
    //contien all attribute that may i need and what should i display
    class BuildingTable
    {
        //Building
        public int BuildingId { get; set; }
        public char BuildingNumber { get; set; }
        public int NumberOfFloors { get; set; }
        public List<Floor> Floors { get; set; }
        //location
        public int CountryId { get; set; }
        public string Country { get; set; }
        public int CityId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        //Building manager
        public int BuildingManagerId { get; set; }
        public string BuildingManagerName { get; set; }
        public string BuildingManagerEmail { get; set; }
    }
}
