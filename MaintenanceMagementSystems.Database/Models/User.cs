using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Database.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]     
        [RegularExpression(@" ^[0-9]*$", ErrorMessage = "Please Enter valid phone number")]
        public string Phone { get; set; }

        [Required]      
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please Enter valid Email")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$", ErrorMessage = "Please Enter valid Password")]
        public string Password { get; set; }

        [ForeignKey("Id")]
        [Required]
        public int UserRoleId { get; set; }

        [ForeignKey("Id")]
        public int FloorId { get; set; }

        [ForeignKey("Id")]
        [Required]
        public int BuildingId { get; set; }



        [ForeignKey("Id")]
        public int JobTitleId { get; set; }
       
       
        [ForeignKey("Id")]
        public int MaintenanceTypeId { get; set; }

    }
}
