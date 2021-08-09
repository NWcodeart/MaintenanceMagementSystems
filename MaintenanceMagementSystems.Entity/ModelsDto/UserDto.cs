using MaintenanceManagementSystem.Entity.LookupDto;
using MaintenanceManagementSystem.Entity.ManyToManyDto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaintenanceManagementSystem.Entity.ModelsDto
{
    public class UserDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-z\s]+$", ErrorMessage = "Accepted characters are alphabets and spaces only")]
        public string Name { get; set; }

        [Required]     
        [RegularExpression(@"^[0-9]*$", ErrorMessage = "Please Enter valid phone number")]
        public string Phone { get; set; }

        [Required]      
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Please Enter valid Email")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[A-Z])(?=.*[@$!%*?&_-])([a-zA-Z0-9@$!%*?&_-]{8,})$", ErrorMessage = "Please Enter valid Password")]
        public string Password { get; set; }

        public bool IsForgetPassword { get; set; } = false;

        //UserRole section
        [ForeignKey("Id")]
        [Required]
        public int UserRoleId { get; set; }

        public UserRoleDto userRole { get; set; }


        //user location section
        [ForeignKey("Id")]
        public int? FloorId { get; set; }

        public FloorDto floor { get; set; }

        public BuildingDto building { get; set; }

        //JobType section
        [ForeignKey("Id")]
        public int? JobTypeId { get; set; }

        public JobTypeDto jobType { get; set; }


        //Maintenance type section
        [ForeignKey("Id")]
        public int? MaintenanceTypeId { get; set; }

        public MaintenanceTypeDto maintenanceType { get; set; }


        #nullable enable
        //Ticket relations 
        public ICollection<TicketDto>? BeneficiaryTickets { get; set; }
        public ICollection<BackOfficesTicketsDto>? BackOfficeTickets { get; set; }

        public ICollection<TicketDto>? TicketsRejected { get; set; }

        public bool IsDeleted { get; set; } = false;

    }
}
