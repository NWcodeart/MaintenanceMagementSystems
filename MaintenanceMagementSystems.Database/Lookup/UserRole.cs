using MaintenanceManagementSystem.Database.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceManagementSystem.Database.Lookup
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [RegularExpression(@"^[a-zA-z]+$", ErrorMessage = "Accepted characters are alphabets only")] //Alpha without spaces
        public string RoleType { get; set; }

        [Required]
        public string RoleNameAr { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-z\s]+$", ErrorMessage = "Accepted characters are alphabets and spaces only")] //Alpha and spaces
        public string RoleNameEn { get; set; }

        public ICollection<User> users { get; set; }
    }
}
