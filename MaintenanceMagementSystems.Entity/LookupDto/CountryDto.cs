using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MaintenanceManagementSystem.Entity.LookupDto
{
    public class CountryDto
    {
        public int Id { get; set; }
        public string CountryNameAr { get; set; }
        public string CountryNameEn { get; set; }
        public List<CityDto> Cities { get; set; }

    }
}
