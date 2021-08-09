using MaintenanceManagementSystem.Entity.ModelsDto;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceManagementSystem.Entity.LookupDto
{
    public class JobTypeDto
    {
        [Key]
        public int Id  { get; set; }
        
        [Required]
        public string JobTypeNameAr { get; set; }

        [Required]
        [RegularExpression(@"^[[:alpha:]\s]+$", ErrorMessage = "Accepted characters are alphabets and spaces only")] //Alpha and spaces
        public string JobTypeNameEn { get; set; }

        public ICollection<UserDto> users { get; set; }
    }
}
