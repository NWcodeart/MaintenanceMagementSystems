using System.ComponentModel.DataAnnotations;

namespace MaintenanceManagementSystem.Database.Lookup
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string StatusTypeAr { get; set; }
        
        [Required]
        public string StatusTypeEn { get; set; }
    }
}
