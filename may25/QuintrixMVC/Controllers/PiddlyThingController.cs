using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuintrixMVC.Data;
using QuintrixMVC.Models;

namespace QuintrixMVC
{
    public class PiddlyThingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PiddlyThingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PiddlyThing
        public async Task<IActionResult> Index()
        {
              return _context.PiddlyThing != null ? 
                          View(await _context.PiddlyThing.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.PiddlyThing'  is null.");
        }

        // GET: PiddlyThing/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.PiddlyThing == null)
            {
                return NotFound();
            }

            var piddlyThing = await _context.PiddlyThing
                .FirstOrDefaultAsync(m => m.Id == id);
            if (piddlyThing == null)
            {
                return NotFound();
            }

            return View(piddlyThing);
        }

        // GET: PiddlyThing/Create
        public IActionResult Create()
        {
            return View(new PiddlyThing());
        }

        // POST: PiddlyThing/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] PiddlyThing piddlyThing)
        {
            if (ModelState.IsValid)
            {
                piddlyThing.Id = Guid.NewGuid();
                _context.Add(piddlyThing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(piddlyThing);
        }

        // GET: PiddlyThing/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.PiddlyThing == null)
            {
                return NotFound();
            }

            var piddlyThing = await _context.PiddlyThing.FindAsync(id);
            if (piddlyThing == null)
            {
                return NotFound();
            }
            return View(piddlyThing);
        }

        // POST: PiddlyThing/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description")] PiddlyThing piddlyThing)
        {
            if (id != piddlyThing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(piddlyThing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PiddlyThingExists(piddlyThing.Id))
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
            return View(piddlyThing);
        }

        // GET: PiddlyThing/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.PiddlyThing == null)
            {
                return NotFound();
            }

            var piddlyThing = await _context.PiddlyThing
                .FirstOrDefaultAsync(m => m.Id == id);
            if (piddlyThing == null)
            {
                return NotFound();
            }

            return View(piddlyThing);
        }

        // POST: PiddlyThing/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.PiddlyThing == null)
            {
                return Problem("Entity set 'ApplicationDbContext.PiddlyThing'  is null.");
            }
            var piddlyThing = await _context.PiddlyThing.FindAsync(id);
            if (piddlyThing != null)
            {
                _context.PiddlyThing.Remove(piddlyThing);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PiddlyThingExists(Guid id)
        {
          return (_context.PiddlyThing?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
