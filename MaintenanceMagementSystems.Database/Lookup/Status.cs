﻿using System.ComponentModel.DataAnnotations;

namespace MaintenanceManagementSystem.Database.Lookup
{
    public class Status
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string StatusTypeAr { get; set; }
        
        [Required]
        [RegularExpression(@"^[[:alpha:]\s]+$", ErrorMessage = "Accepted characters are alphabets and spaces only")] //Alpha and spaces
        public string StatusTypeEn { get; set; }
    }
}
