using System.ComponentModel.DataAnnotations;

namespace MaintenanceManagementSystem.Database.Lookup
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Role { get; set; }
    }
}
