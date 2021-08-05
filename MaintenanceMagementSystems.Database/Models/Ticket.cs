﻿using MaintenanceManagementSystem.Database.Lookup;
using MaintenanceManagementSystem.Database.ManyToMany;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaintenanceManagementSystem.Database.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        //Beneficiary section
        [Display(Name = "Beneficiary ID")]
        [ForeignKey("BeneficiaryUser")]
        public int BeneficiaryID { get; set; }

        public User BeneficiaryUser { get; set; }

        //BackOffice section relation
        #nullable enable
        public ICollection<BackOfficesTickets>? backOfficesTickets { get; set; }

        //status section
        [Required]
        public int StatusID { get; set; }
        #nullable disable
        public Status status { get; set; }

        [Required]
        public int ApprovalState { get; set; }


        //Date section
        [Required]
        public DateTime Date { get; set; }

        //Picture section
        #nullable enable
        [RegularExpression(@"([0-9a-zA-Z\._-]+.(png|PNG|gif|GIF|jp[e]?g|JP[E]?G))", ErrorMessage = "Accepted file type is image only")] //Image file names
        public string? Picture { get; set; }

        //Maintenance type section
        [Required]
        [Display(Name = "Maintenance Type")]
        public int MaintenanceTypeID { get; set; }

        #nullable disable
        public MaintenanceType maintenanceType { get; set; }

        //Description section
        [RegularExpression(@"^[[:alpha:]\s]+$", ErrorMessage = "Accepted characters are alphabets and spaces only")] //Alpha and spaces
        [Required]
        public string Description { get; set; }

        //comment section
        #nullable enable
        [RegularExpression(@"^[[:alpha:]\s]+$", ErrorMessage = "Accepted characters are alphabets and spaces only")] //Alpha and spaces
        public string? BuildingManagerComment { get; set; }

        //Ticket location floor section
        [Display(Name = "Floor Number")]
        public int? FloorId { get; set; }

        public Floor? floor { get; set; }


        //Canceled section 
        [Required]
        [Display(Name = "Is Canceled?")]
        public bool IsCancelled { get; set; } = false;

        #nullable enable
        public int? CancellationReasonID { get; set; }

        public CancelationReason? cancelationReason { get; set; }


        //Rejection section
        [Display(Name = "Rejected By")]
        public int? RejectedBy { get; set; }

        public User? UserRejected { get; set; }

        [RegularExpression(@"^[[:alpha:]\s]+$", ErrorMessage = "Accepted characters are alphabets and spaces only")] //Alpha and spaces
        [Display(Name = "Rejection Reason")]
        public string? RejectionReason { get; set; }

        //audit trail
        public int CreatedBy { get; set; }

        public DateTime CreatedTime { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedTime { get; set; }

        public bool IsDeleted{ get; set; }
    }
}
