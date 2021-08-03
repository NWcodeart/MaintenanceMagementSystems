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
        [Required]
        public int Id { get; set; }

        [Required]
        public char Number { get; set; }

        [Required]
        public bool IsOwned { get; set; }

        [Required]
        [ForeignKey("Id")]
        public int CountryId { get; set; }

        [Required]
        [ForeignKey("Id")]
        public int CityId { get; set; }

        [Required]
        public string Street { get; set; }
    }
}
