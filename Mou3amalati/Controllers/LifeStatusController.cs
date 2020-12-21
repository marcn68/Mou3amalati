using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mou3amalati.Data;
using Mou3amalati.Models;

namespace Mou3amalati.Controllers
{
    public class LifeStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LifeStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LifeStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.LifeStatuses.ToListAsync());
        }

        // GET: LifeStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lifeStatus = await _context.LifeStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lifeStatus == null)
            {
                return NotFound();
            }

            return View(lifeStatus);
        }

        // GET: LifeStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LifeStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Status")] LifeStatus lifeStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lifeStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lifeStatus);
        }

        // GET: LifeStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lifeStatus = await _context.LifeStatuses.FindAsync(id);
            if (lifeStatus == null)
            {
                return NotFound();
            }
            return View(lifeStatus);
        }

        // POST: LifeStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Status")] LifeStatus lifeStatus)
        {
            if (id != lifeStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lifeStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LifeStatusExists(lifeStatus.Id))
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
            return View(lifeStatus);
        }

        // GET: LifeStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lifeStatus = await _context.LifeStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lifeStatus == null)
            {
                return NotFound();
            }

            return View(lifeStatus);
        }

        // POST: LifeStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lifeStatus = await _context.LifeStatuses.FindAsync(id);
            _context.LifeStatuses.Remove(lifeStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LifeStatusExists(int id)
        {
            return _context.LifeStatuses.Any(e => e.Id == id);
        }
    }
}
