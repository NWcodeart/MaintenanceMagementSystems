using System.ComponentModel.DataAnnotations;

namespace MaintenanceManagementSystem.Database.Lookup
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string CityNameAr { get; set; }
        
        [Required]
        public string CityNameEn { get; set; }
    }
}
