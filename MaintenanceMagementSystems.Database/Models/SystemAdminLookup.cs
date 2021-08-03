using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Database.Models
{
    public class SystemAdminLookup
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int MaintenanceClassificationID { get; set; }
        [Required]
        public int MaintenanceTeamID { get; set; }
        [Required]
        public int BuildingID { get; set; }

        [ForeignKey("BuildingID")]
        public ICollection<Building> Buildings { get; set; }
        [ForeignKey("MaintenanceTeamID")]
        public ICollection<User> Users { get; set; }
        [ForeignKey("MaintenanceClassificationID")]
        public ICollection<Ticket> Tickets { get; set; }

        public SystemAdminLookup()
        {
            Buildings = new List<Building>();
            Users = new List<User>();
            Tickets = new List<Ticket>();
        }
    }
}
