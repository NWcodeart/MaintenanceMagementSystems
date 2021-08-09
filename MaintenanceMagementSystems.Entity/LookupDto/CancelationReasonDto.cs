using MaintenanceManagementSystem.Entity.ModelsDto;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceManagementSystem.Entity.LookupDto
{
    public class CancelationReasonDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ReasonTypeAr { get; set; }

        [Required]
        public string ReasonTypeEn { get; set; }

        public ICollection<TicketDto> tickets { get; set; }
    }
}
