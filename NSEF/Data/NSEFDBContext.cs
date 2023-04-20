using Microsoft.EntityFrameworkCore;
using NSEF.Models;

namespace NSEF.Data
{
    public class NSEFDBContext : DbContext
    {
        public NSEFDBContext(DbContextOptions<NSEFDBContext> options)
            : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Absence> Absences { get; set; }
        public DbSet<EmployeeAbsence> EmployeeAbsences { get; set; }
    }
}
