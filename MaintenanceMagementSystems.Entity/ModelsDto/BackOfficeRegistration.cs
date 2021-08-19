using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Entity.ModelsDto
{
    public class BackOfficeRegistration
    {
        [Required]
        [RegularExpression(@"^[a-zA-z\s]+$", ErrorMessage = "Accepted characters are alphabets and spaces only")] //Alpha and spaces
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please Enter valid Email")]
        public string Email { get; set; }

        [Required]
        public int UserRoleId { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Please Enter valid phone number")]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[A-Z])(?=.*[@$!%*?&_-])([a-zA-Z0-9@$!%*?&_-]{8,})$", ErrorMessage = "Please Enter valid Password")]
        public string Password { get; set; }

        [Required]
        public int BuildingNumber { get; set; }

        [Required]
        public int FloorNumber { get; set; }

        #nullable enable
        public int? MaintenanceTypeId { get; set; }
    }
}
