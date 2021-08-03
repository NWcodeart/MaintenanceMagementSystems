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
    }
}
