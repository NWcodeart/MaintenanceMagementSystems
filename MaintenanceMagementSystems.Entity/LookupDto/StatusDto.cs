using MaintenanceManagementSystem.Entity.ModelsDto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceManagementSystem.Entity.LookupDto
{
    public class StatusDto
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string StatusTypeAr { get; set; }
        
        [Required]
        [RegularExpression(@"^[[:alpha:]\s]+$", ErrorMessage = "Accepted characters are alphabets and spaces only")] //Alpha and spaces
        public string StatusTypeEn { get; set; }

        public ICollection<TicketDto> ticket { get; set; }
    }
}
