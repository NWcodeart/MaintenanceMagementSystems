using MaintenanceManagementSystem.Entity.ModelsDto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceManagementSystem.Entity.LookupDto
{
    public class UserRoleDto
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Role { get; set; }

        public ICollection<UserDto> users { get; set; }
    }
}
