using System.ComponentModel.DataAnnotations;

namespace MaintenanceManagementSystem.Database
{
    public class JobType
    {
        [Key]
        public int Id  { get; set; }
        
        [Required]
        public string JobTypeNameAr { get; set; }

        [Required]
        [RegularExpression(@"^[[:alpha:]\s]+$", ErrorMessage = "Accepted characters are alphabets and spaces only")] //Alpha and spaces
        public string JobTypeNameEn { get; set; }
    }
}
