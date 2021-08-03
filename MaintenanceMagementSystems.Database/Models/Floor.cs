using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Database.Models
{
    public class Floor
    {
        [Key]
        public int Id { get; set; }

        [Key]
        [Required]
        public char Number { get; set; }

        [ForeignKey("Id")]
        [Required]
        public int BuildingId { get; set; }
        public Building building { get; set; }

        public ICollection<Ticket> tickets { get; set; }
        public ICollection<User> users { get; set; }
    }
}
