using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SparkelStrands.Models;
using Sparkle.Data;

namespace Sparkle.Controllers
{
    public class BraceletesController : Controller
    {
        private readonly SparkleContext _context;

        public BraceletesController(SparkleContext context)
        {
            _context = context;
        }

        // GET: Braceletes
        public async Task<IActionResult> Index()
        {
              return _context.Bracelete != null ? 
                          View(await _context.Bracelete.ToListAsync()) :
                          Problem("Entity set 'SparkleContext.Bracelete'  is null.");
        }

        // GET: Braceletes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bracelete == null)
            {
                return NotFound();
            }

            var bracelete = await _context.Bracelete
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bracelete == null)
            {
                return NotFound();
            }

            return View(bracelete);
        }

        // GET: Braceletes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Braceletes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Material,Length,Beads,Color,ClaspType,Price,Brand")] Bracelete bracelete)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bracelete);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bracelete);
        }

        // GET: Braceletes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bracelete == null)
            {
                return NotFound();
            }

            var bracelete = await _context.Bracelete.FindAsync(id);
            if (bracelete == null)
            {
                return NotFound();
            }
            return View(bracelete);
        }

        // POST: Braceletes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Material,Length,Beads,Color,ClaspType,Price,Brand")] Bracelete bracelete)
        {
            if (id != bracelete.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bracelete);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BraceleteExists(bracelete.Id))
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
            return View(bracelete);
        }

        // GET: Braceletes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bracelete == null)
            {
                return NotFound();
            }

            var bracelete = await _context.Bracelete
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bracelete == null)
            {
                return NotFound();
            }

            return View(bracelete);
        }

        // POST: Braceletes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bracelete == null)
            {
                return Problem("Entity set 'SparkleContext.Bracelete'  is null.");
            }
            var bracelete = await _context.Bracelete.FindAsync(id);
            if (bracelete != null)
            {
                _context.Bracelete.Remove(bracelete);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BraceleteExists(int id)
        {
          return (_context.Bracelete?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
