using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Entity.ModelsDto
{
    public class FloorDto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public char Number { get; set; }

        [Required]
        [ForeignKey("Id")]
        public int BuildingId { get; set; }
        public BuildingDto building { get; set; }

        public ICollection<TicketDto> tickets { get; set; }
        public ICollection<UserDto> users { get; set; }
    }
}
