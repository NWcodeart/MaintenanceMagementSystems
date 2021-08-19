using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Entity.ModelsDto
{
    public class TicketRequest
    {
        [Required(ErrorMessage = "Please enter a description of the problem")]
        [RegularExpression(@"^(?:[a-zA-Z0-9\s@,=%$#&_\u0600-\u06FF\u0750-\u077F\u08A0-\u08FF\uFB50-\uFDCF\uFDF0-\uFDFF\uFE70-\uFEFF]|(?:\uD802[\uDE60-\uDE9F]|\uD83B[\uDE00-\uDEFF])){0,30}$", ErrorMessage = "Accepted characters are alphabets and spaces only")] //Alpha and spaces
        public string Description { get; set; }

        [Required(ErrorMessage = "Please choose a type of maintenance")]
        public int MaintenanceTypeID { get; set; }

        [Required(ErrorMessage = "Please enter date and time for the maintenance")]
        public DateTime Date { get; set; }

        #nullable enable
        [RegularExpression(@"([0-9a-zA-Z\._-]+.(png|PNG|gif|GIF|jp[e]?g|JP[E]?G))", ErrorMessage = "Accepted file type is image only")] //Image file names
        public string? Picture { get; set; }
    }
}
