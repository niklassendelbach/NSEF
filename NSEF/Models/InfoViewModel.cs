using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NSEF.Models
{
    public class InfoViewModel
    {
        [DisplayName("First name")]
        public string FirstName { get; set; }
        [DisplayName("Last name")]
        public string LastName { get; set; }
        [DisplayName("Absence type")]
        public string AbsenceType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [DisplayName("Created")]
        public DateTime CreatedAt { get; set; }
        [DisplayName("Days of absence")]
        public double TotalDays { get; set; }
    }
}
