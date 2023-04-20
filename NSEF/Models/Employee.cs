using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSEF.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; } = 0;
        [Required]
        [StringLength(30)]
        [DisplayName("First name")]
        public string FirstName { get; set; } = default!;
        [Required]
        [StringLength(30)]
        [DisplayName("Last name")]
        public string LastName { get; set; } = default!;
        public virtual ICollection<EmployeeAbsence>? EmployeeAbsences { get; set; } // nav
    }
}
