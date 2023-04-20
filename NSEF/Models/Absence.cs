using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSEF.Models
{
    public class Absence
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AbsenceId { get; set; }
        [StringLength(50)]
        [DisplayName("Absence type")]
        public string AbsenceType { get; set; }
        public virtual ICollection<EmployeeAbsence>? EmployeeAbsences { get; set; } // nav
    }
}
