using MaintenanceManagementSystem.Database.Models;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceManagementSystem.Database.Lookup
{
    public class CancelationReason
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ReasonTypeAr { get; set; }

        [Required]
        public string ReasonTypeEn { get; set; }

        public ICollection<Ticket> tickets { get; set; }
    }
}
