using System.ComponentModel.DataAnnotations;

namespace MaintenanceManagementSystem.Database.Lookup
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string CountryNameAr { get; set; }
        
        [Required]
        public string CountryNameEn { get; set; }
    }
}
