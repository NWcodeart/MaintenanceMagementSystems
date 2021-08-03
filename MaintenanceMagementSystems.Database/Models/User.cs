﻿using MaintenanceManagementSystem.Database.Lookup;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        //UserRole section
        [ForeignKey("Id")]
        [Required]
        public int UserRoleId { get; set; }

        public UserRole userRole { get; set; }


        //user location section
        [ForeignKey("Id")]
        public int? FloorId { get; set; }

        public Floor floor { get; set; }

        //JobType section
        [ForeignKey("Id")]
        public int? JobTypeId { get; set; }

        public JobType jobType { get; set; }


        //Maintenance type section
        [ForeignKey("Id")]
        public int? MaintenanceTypeId { get; set; }

        public MaintenanceType maintenanceType { get; set; }

        //Ticket relations 
        #nullable enable
        public ICollection<Ticket>? BackOfficeTickets { get; set; }
        
        [ForeignKey("Id")]
        public int? BeneficiaryTicketId { get; set; }

        public Ticket? BeneficiaryTicket { get; set; }
    }
}