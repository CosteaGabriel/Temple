using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Temple.Data;
using Temple.Models;

namespace Temple.Controllers
{
    public class PacientsController : Controller
    {
        private readonly TempleContext _context;

        public PacientsController(TempleContext context)
        {
            _context = context;
        }

        // GET: Pacients
        public async Task<IActionResult> Index()

        {
            return View(await _context.Pacients.ToListAsync());
        }

        // GET: Pacients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacient = await _context.Pacients
              .Include(s => s.Distributions)
                    .ThenInclude(e => e.Doctor)
              .AsNoTracking()
              .SingleOrDefaultAsync(m => m.PacientID == id);

            if (pacient == null)
            {
                return NotFound();
            }

            return View(pacient);
        }

        // GET: Pacients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pacients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstMidName,LastName,EnrollmentDate")] Pacient pacient)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(pacient);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(DbUpdateException ex)
            {
                //Log the error
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }
            return View(pacient);
        }

        // GET: Pacients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacient = await _context.Pacients.SingleOrDefaultAsync(m => m.PacientID == id);
            if (pacient == null)
            {
                return NotFound();
            }
            return View(pacient);
        }

        // POST: Pacients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id ==null)
            {
                return NotFound();
            }

            var pacientToUpdate = await _context.Pacients.SingleOrDefaultAsync(s => s.PacientID == id);
            if (await TryUpdateModelAsync<Pacient>(pacientToUpdate, "", s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            {
                try
                {
                    //_context.Update(pacient);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException)
                {
                    // Log the error
                    ModelState.AddModelError("", "Unable to save changes." +
                        "Try again, and if the problem persists, see your system administrator");

                    //if (!PacientExists(pacient.PacientID))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                //return RedirectToAction(nameof(Index));
            }
            return View(pacientToUpdate);
        }

        // GET: Pacients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pacient = await _context.Pacients
                .SingleOrDefaultAsync(m => m.PacientID == id);
            if (pacient == null)
            {
                return NotFound();
            }

            return View(pacient);
        }

        // POST: Pacients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pacient = await _context.Pacients.SingleOrDefaultAsync(m => m.PacientID == id);
            _context.Pacients.Remove(pacient);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PacientExists(int id)
        {
            return _context.Pacients.Any(e => e.PacientID == id);
        }
    }
}
