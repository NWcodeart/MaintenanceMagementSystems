using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Database.Models
{
    public class JobTitleLookup
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [RegularExpression(@"^[[:alpha:]\s]+$", ErrorMessage = "Accepted characters are alphabets and spaces only")] //Alpha and spaces
        public string JobTitleEn { get; set; }
        [Required]
        public string JobTitleAr { get; set; }

        [ForeignKey("ID")]
        public ICollection<User> Users { get; set; }

        public JobTitleLookup()
        {
            Users = new List<User>();
        }
    }
}
