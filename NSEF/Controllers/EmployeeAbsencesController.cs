using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NSEF.Data;
using NSEF.Models;

namespace NSEF.Controllers
{
    public class EmployeeAbsencesController : Controller
    {
        private readonly NSEFDBContext _context;

        public EmployeeAbsencesController(NSEFDBContext context)
        {
            _context = context;
        }

        // GET: EmployeeAbsences & searchresult
        public async Task<IActionResult> Index(String SearchString)
        {
            
            var nSEFDBContext = _context.EmployeeAbsences.Include(e => e.Absences).Include(e => e.Employees);
            if (!String.IsNullOrEmpty(SearchString))
            {
                return View("Index", await nSEFDBContext.Where(e => e.Employees.FirstName.Contains(SearchString)).ToListAsync());
            }
            return View(await nSEFDBContext.ToListAsync());
        }

        // GET: EmployeeAbsences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmployeeAbsences == null)
            {
                return NotFound();
            }

            var employeeAbsence = await _context.EmployeeAbsences
                .Include(e => e.Absences)
                .Include(e => e.Employees)
                .FirstOrDefaultAsync(m => m.EmployeeAbsenceId == id);
            if (employeeAbsence == null)
            {
                return NotFound();
            }

            return View(employeeAbsence);
        }

        // GET: EmployeeAbsences/Create
        public IActionResult Create()
        {
            //Går det å ändra från ViewData till något annat för att visa både för- å efternamn istället för fk_empid?
            ViewData["FK_AbsenceId"] = new SelectList(_context.Absences, "AbsenceId", "AbsenceType");
            ViewData["FK_EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName");
            return View();
        }

        // POST: EmployeeAbsences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmployeeAbsenceId,StartDate,EndDate,FK_EmployeeId,FK_AbsenceId")] EmployeeAbsence employeeAbsence)
        {
            if (ModelState.IsValid)
            {
                employeeAbsence.CreatedAt = DateTime.Now;
                _context.Add(employeeAbsence);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FK_AbsenceId"] = new SelectList(_context.Absences, "AbsenceId", "AbsenceType", employeeAbsence.FK_AbsenceId);
            ViewData["FK_EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName", employeeAbsence.FK_EmployeeId);
            return View(employeeAbsence);
        }

        // GET: EmployeeAbsences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmployeeAbsences == null)
            {
                return NotFound();
            }

            var employeeAbsence = await _context.EmployeeAbsences.FindAsync(id);
            if (employeeAbsence == null)
            {
                return NotFound();
            }
            ViewData["FK_AbsenceId"] = new SelectList(_context.Absences, "AbsenceId", "AbsenceType", employeeAbsence.FK_AbsenceId);
            ViewData["FK_EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName", employeeAbsence.FK_EmployeeId);
            return View(employeeAbsence);
        }

        // POST: EmployeeAbsences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmployeeAbsenceId,StartDate,EndDate,FK_EmployeeId,FK_AbsenceId")] EmployeeAbsence employeeAbsence)
        {
            if (id != employeeAbsence.EmployeeAbsenceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeAbsence);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeAbsenceExists(employeeAbsence.EmployeeAbsenceId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FK_AbsenceId"] = new SelectList(_context.Absences, "AbsenceId", "AbsenceType", employeeAbsence.FK_AbsenceId);
            ViewData["FK_EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName", employeeAbsence.FK_EmployeeId);
            return View(employeeAbsence);
        }

        // GET: EmployeeAbsences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmployeeAbsences == null)
            {
                return NotFound();
            }

            var employeeAbsence = await _context.EmployeeAbsences
                .Include(e => e.Absences)
                .Include(e => e.Employees)
                .FirstOrDefaultAsync(m => m.EmployeeAbsenceId == id);
            if (employeeAbsence == null)
            {
                return NotFound();
            }

            return View(employeeAbsence);
        }

        // POST: EmployeeAbsences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmployeeAbsences == null)
            {
                return Problem("Entity set 'NSEFDBContext.EmployeeAbsences'  is null.");
            }
            var employeeAbsence = await _context.EmployeeAbsences.FindAsync(id);
            if (employeeAbsence != null)
            {
                _context.EmployeeAbsences.Remove(employeeAbsence);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeAbsenceExists(int id)
        {
          return (_context.EmployeeAbsences?.Any(e => e.EmployeeAbsenceId == id)).GetValueOrDefault();
        }
    }
}
