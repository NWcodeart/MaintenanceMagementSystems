using MaintenanceManagementSystem.Entity.LookupDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Entity.ModelsDto
{
    public class BuildingDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public char Number { get; set; }

        [Required]
        public bool IsOwned { get; set; } 

        [Required]
        [ForeignKey("Id")]
        public int CityId { get; set; }
        public CityDto city { get; set; }

        #nullable enable
        public string? Street { get; set; }

        [Required]
        #nullable disable
        public ICollection<FloorDto> floors { get; set; }


        public int BuildingManagerId { get; set; }
        public UserDto UserbuildingManager { get; set; }


    }
}
