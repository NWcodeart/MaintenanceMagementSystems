using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Entity.ModelsDto
{
    public class BuildingAdd
    {
        public char BuildingNumber { get; set; }
        public int CityId { get; set; }
        public string Street { get; set; }
        //Building manager
        public int? BuildingManagerId { get; set; }
        //Is Owned
        public bool IsOwned { get; set; }
    }
}
