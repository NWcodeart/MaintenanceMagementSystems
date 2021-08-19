using MaintenanceManagementSystem.Entity.ModelsDto;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceManagementSystem.Entity.LookupDto
{
    public class CancelationReasonDto
    {
        public int Id { get; set; }

        public string ReasonTypeAr { get; set; }
        public string ReasonTypeEn { get; set; }
    }
}
