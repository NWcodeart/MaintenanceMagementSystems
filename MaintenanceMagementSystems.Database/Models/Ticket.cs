using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaintenanceManagementSystem.Database.Models
{
    public class Ticket
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [RegularExpression(@"^[[:alpha:]\s]+$", ErrorMessage = "Accepted characters are alphabets and spaces only")] //Alpha and spaces
        public int StateID { get; set; }
        [Required]
        [RegularExpression(@"^[[:alpha:]\s]+$", ErrorMessage = "Accepted characters are alphabets and spaces only")] //Alpha and spaces
        [Display(Name = "Approval State")]
        public string ApprovalState { get; set; }
        [Required]
        public DateTime Date { get; set; }
        #nullable enable
        [RegularExpression(@"([0-9a-zA-Z\._-]+.(png|PNG|gif|GIF|jp[e]?g|JP[E]?G))", ErrorMessage = "Accepted file type is image only")] //Image file names
        public string? Picture { get; set; }
        [Required]
        [Display(Name = "Maintenance Type")]
        public int MaintenanceTypeID { get; set; }
        [Required]
        [RegularExpression(@"^[[:alpha:]\s]+$", ErrorMessage = "Accepted characters are alphabets and spaces only")] //Alpha and spaces
        public string Description { get; set; }
        [Required]
        [Display(Name = "Floor Number")]
        public int? FloorNumber { get; set; }
        [Required]
        [Display(Name = "Is Canceled?")]
        public bool IsCanceled { get; set; }
        #nullable enable
        public int CancellationReasonID { get; set; }
        [Display(Name = "Rejected By")]
        public int? RejectedBy { get; set; }
        [RegularExpression(@"^[[:alpha:]\s]+$", ErrorMessage = "Accepted characters are alphabets and spaces only")] //Alpha and spaces
        [Display(Name = "Rejection Reason")]
        public string? RejectionReason { get; set; }
        [Required]
        [Display(Name = "Beneficiary ID")]
        public int BeneficiaryID { get; set; }

        [ForeignKey("CancelationReasonID")]
        public CancelationReason CancelationReason { get; set; }
        [ForeignKey("MaintenanceTypeID")]
        public ICollection<MaintenanceType> MaintenanceType { get; set; }
        [ForeignKey("BeneficiaryID")]
        public ICollection<User> Users { get; set; }

        [ForeignKey("StateID")]
        public ICollection<State> States { get; set; }
        public Ticket()
        {
            MaintenanceTeam = new List<MaintenanceTeam>();
            Users = new List<User>();
            State = new State();
            CancelationReasons = new CancelationReason;
        }
    }
}
