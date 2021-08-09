using MaintenanceManagementSystem.Entity.ModelsDto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceManagementSystem.Entity.LookupDto
{
    public class MaintenanceTypeDto
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string MaintenanceTypeNameAr { get; set; }
        
        [Required]
        public string MaintenanceTypeNameEn { get; set; }

        public ICollection<TicketDto> tickets { get; set; }
        public ICollection<UserDto> users { get; set; }
    }
}
