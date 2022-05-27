using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuintrixMVC.Data;
using QuintrixMVC.Models;

namespace QuintrixMVC.Controllers
{
    public class ValuableThingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ValuableThingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ValuableThing
        public async Task<IActionResult> Index()
        {
              return _context.ValuableThing != null ? 
                          View(await _context.ValuableThing.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ValuableThing'  is null.");
        }

        // GET: ValuableThing/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.ValuableThing == null)
            {
                return NotFound();
            }

            var valuableThing = await _context.ValuableThing
                .FirstOrDefaultAsync(m => m.Id == id);
            if (valuableThing == null)
            {
                return NotFound();
            }

            return View(valuableThing);
        }

        // GET: ValuableThing/Create
        [Authorize(Roles = "Gigachad")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ValuableThing/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Gigachad")]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Value")] ValuableThing valuableThing)
        {
            if (ModelState.IsValid)
            {
                valuableThing.Id = Guid.NewGuid();
                _context.Add(valuableThing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(valuableThing);
        }

        // GET: ValuableThing/Edit/5
        [Authorize(Roles = "Gigachad")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.ValuableThing == null)
            {
                return NotFound();
            }

            var valuableThing = await _context.ValuableThing.FindAsync(id);
            if (valuableThing == null)
            {
                return NotFound();
            }
            return View(valuableThing);
        }

        // POST: ValuableThing/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Gigachad")]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description,Value")] ValuableThing valuableThing)
        {
            if (id != valuableThing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(valuableThing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ValuableThingExists(valuableThing.Id))
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
            return View(valuableThing);
        }

        // GET: ValuableThing/Delete/5
        [Authorize(Roles = "Gigachad")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.ValuableThing == null)
            {
                return NotFound();
            }

            var valuableThing = await _context.ValuableThing
                .FirstOrDefaultAsync(m => m.Id == id);
            if (valuableThing == null)
            {
                return NotFound();
            }

            return View(valuableThing);
        }

        // POST: ValuableThing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Gigachad")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.ValuableThing == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ValuableThing'  is null.");
            }
            var valuableThing = await _context.ValuableThing.FindAsync(id);
            if (valuableThing != null)
            {
                _context.ValuableThing.Remove(valuableThing);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ValuableThingExists(Guid id)
        {
          return (_context.ValuableThing?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
