using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceManagementSystem.Entity.LookupDto
{
    public class CountryDto
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string CountryNameAr { get; set; }
        
        [Required]
        public string CountryNameEn { get; set; }
        public ICollection<CityDto> Cities { get; set; }

    }
}
