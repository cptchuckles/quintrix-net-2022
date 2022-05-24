using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuintrixMVC.Data;
using QuintrixMVC.Models;

namespace QuintrixMVC.Controllers
{
    public class RobotController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RobotController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Robot
        public async Task<IActionResult> Index()
        {
              return _context.Robot != null ? 
                          View(await _context.Robot.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Robot'  is null.");
        }

        // GET: Robot/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Robot == null)
            {
                return NotFound();
            }

            var robot = await _context.Robot
                .FirstOrDefaultAsync(m => m.Id == id);
            if (robot == null)
            {
                return NotFound();
            }

            return View(robot);
        }

        // GET: Robot/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Robot/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,PowerLevel")] Robot robot)
        {
            if (ModelState.IsValid)
            {
                robot.Id = Guid.NewGuid();
                _context.Add(robot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(robot);
        }

        // GET: Robot/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Robot == null)
            {
                return NotFound();
            }

            var robot = await _context.Robot.FindAsync(id);
            if (robot == null)
            {
                return NotFound();
            }
            return View(robot);
        }

        // POST: Robot/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,PowerLevel")] Robot robot)
        {
            if (id != robot.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(robot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RobotExists(robot.Id))
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
            return View(robot);
        }

        // GET: Robot/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Robot == null)
            {
                return NotFound();
            }

            var robot = await _context.Robot
                .FirstOrDefaultAsync(m => m.Id == id);
            if (robot == null)
            {
                return NotFound();
            }

            return View(robot);
        }

        // POST: Robot/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Robot == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Robot'  is null.");
            }
            var robot = await _context.Robot.FindAsync(id);
            if (robot != null)
            {
                _context.Robot.Remove(robot);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RobotExists(Guid id)
        {
          return (_context.Robot?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
