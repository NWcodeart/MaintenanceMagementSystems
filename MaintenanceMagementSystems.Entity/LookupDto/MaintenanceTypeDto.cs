using MaintenanceManagementSystem.Entity.ModelsDto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceManagementSystem.Entity.LookupDto
{
    public class MaintenanceTypeDto
    {
        public int Id { get; set; }
        
        public string MaintenanceTypeNameAr { get; set; }
        public string MaintenanceTypeNameEn { get; set; }

    }
}
