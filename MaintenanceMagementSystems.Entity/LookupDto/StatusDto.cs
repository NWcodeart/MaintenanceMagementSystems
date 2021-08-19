using MaintenanceManagementSystem.Entity.ModelsDto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceManagementSystem.Entity.LookupDto
{
    public class StatusDto
    {
        public int Id { get; set; }
        public string StatusTypeAr { get; set; }
        public string StatusTypeEn { get; set; }

    }
}
