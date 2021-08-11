using MaintenanceManagementSystem.Database.Lookup;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Database.Models
{
    public class Building
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
        public City city { get; set; }

        #nullable enable
        public string? Street { get; set; }

        [Required]
        #nullable disable
        public ICollection<Floor> floors { get; set; }


        public int BuildingManagerId { get; set; }
        public User UserbuildingManager { get; set; }
    }
}
