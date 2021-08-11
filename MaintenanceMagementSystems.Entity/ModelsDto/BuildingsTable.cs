using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Entity.ModelsDto
{
    public class BuildingsTable
    {
        //Building
        public int BuildingId { get; set; }
        public char BuildingNumber { get; set; }
        public int NumberOfFloors { get; set; }
        public List<FloorTable> FloorTables { get; set; }
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
