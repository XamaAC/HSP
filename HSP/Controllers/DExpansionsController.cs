using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HSP.Models;

namespace HSP.Controllers
{
    public class DExpansionsController : Controller
    {
        private readonly HearthStonePortalContext _context;

        public DExpansionsController(HearthStonePortalContext context)
        {
            _context = context;
        }

        // GET: DExpansions
        public async Task<IActionResult> Index()
        {
            var hearthStonePortalContext = _context.DExpansions.Include(d => d.IdExpansionSetNavigation);
            return View(await hearthStonePortalContext.ToListAsync());
        }

        // GET: DExpansions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dExpansions = await _context.DExpansions
                .Include(d => d.IdExpansionSetNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (dExpansions == null)
            {
                return NotFound();
            }

            return View(dExpansions);
        }

        // GET: DExpansions/Create
        public IActionResult Create()
        {
            ViewData["IdExpansionSet"] = new SelectList(_context.DExpansionSets, "Id", "Title");
            return View();
        }

        // POST: DExpansions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,IdExpansionSet")] DExpansions dExpansions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dExpansions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdExpansionSet"] = new SelectList(_context.DExpansionSets, "Id", "Title", dExpansions.IdExpansionSet);
            return View(dExpansions);
        }

        // GET: DExpansions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dExpansions = await _context.DExpansions.SingleOrDefaultAsync(m => m.Id == id);
            if (dExpansions == null)
            {
                return NotFound();
            }
            ViewData["IdExpansionSet"] = new SelectList(_context.DExpansionSets, "Id", "Title", dExpansions.IdExpansionSet);
            return View(dExpansions);
        }

        // POST: DExpansions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,IdExpansionSet")] DExpansions dExpansions)
        {
            if (id != dExpansions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dExpansions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DExpansionsExists(dExpansions.Id))
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
            ViewData["IdExpansionSet"] = new SelectList(_context.DExpansionSets, "Id", "Title", dExpansions.IdExpansionSet);
            return View(dExpansions);
        }

        // GET: DExpansions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dExpansions = await _context.DExpansions
                .Include(d => d.IdExpansionSetNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (dExpansions == null)
            {
                return NotFound();
            }

            return View(dExpansions);
        }

        // POST: DExpansions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dExpansions = await _context.DExpansions.SingleOrDefaultAsync(m => m.Id == id);
            _context.DExpansions.Remove(dExpansions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DExpansionsExists(int id)
        {
            return _context.DExpansions.Any(e => e.Id == id);
        }
    }
}
