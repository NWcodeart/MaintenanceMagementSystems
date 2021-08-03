using System.ComponentModel.DataAnnotations;

namespace MaintenanceManagementSystem.Database
{
    public class JobType
    {
        [Key]
        public int Id  { get; set; }
        
        [Required]
        public string JobTypeName { get; set; }
    }
}
