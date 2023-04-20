using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using NSEF.Data;
using NSEF.Models;

namespace NSEF.Controllers
{
    public class InfoController : Controller
    {
        private readonly NSEFDBContext context;
        public InfoController(NSEFDBContext _context)
        {
            context = _context;
        }
        public async Task<IActionResult> Index(DateTime? SearchMonth)
        {
            List<InfoViewModel> list = new List<InfoViewModel>();
            var items = await (from emp in context.Employees
                               join ea in context.EmployeeAbsences on emp.EmployeeId equals ea.FK_EmployeeId
                               join a in context.Absences on ea.FK_AbsenceId equals a.AbsenceId
                               select new
                               {
                                   FirstName = emp.FirstName,
                                   LastName = emp.LastName,
                                   TotalDays = (ea.EndDate.Date - ea.StartDate.Date).Days,
                                   CreatedAt = ea.CreatedAt
                               }).ToListAsync();
            
            //konvertera från anonym
            foreach (var item in items)
            {
                InfoViewModel listItem = new InfoViewModel();
                listItem.FirstName = item.FirstName;
                listItem.LastName = item.LastName;
                listItem.TotalDays = item.TotalDays;
                listItem.CreatedAt = item.CreatedAt;
                list.Add(listItem);
            }
            //resultat när man kollar månad
            if (SearchMonth != null)
            {
                return View("Index", list.Where(e => e.CreatedAt.Month == SearchMonth.Value.Month && e.CreatedAt.Year == SearchMonth.Value.Year));
            }
            return View(list);
        }
    }
}
