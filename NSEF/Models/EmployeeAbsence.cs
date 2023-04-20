using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSEF.Models
{
    public class EmployeeAbsence
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeAbsenceId { get; set; } = 0;
        [DisplayName("Start date")]
        public DateTime StartDate { get; set; }
        [DisplayName("End date")]
        public DateTime EndDate { get; set; }
        [DisplayName("Created")]
        public DateTime CreatedAt { get; set; }
        [ForeignKey("Employees")]
        public int FK_EmployeeId { get; set; }
        public virtual Employee? Employees { get; set; } //nav
        [ForeignKey("Absences")]
        public int FK_AbsenceId { get; set; }
        public virtual Absence? Absences { get; set; } //nav
    }
}
