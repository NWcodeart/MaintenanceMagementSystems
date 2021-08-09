using MaintenanceManagementSystem.Entity.ModelsDto;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceManagementSystem.Entity.LookupDto
{
    public class CityDto
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string CityNameAr { get; set; }
        
        [Required]
        public string CityNameEn { get; set; }

        public ICollection<BuildingDto> buildings { get; set; }

        //country 
        public int CountryId { get; set; }
        public CountryDto country { get; set; }

    }
}
