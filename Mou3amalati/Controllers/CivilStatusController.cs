using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mou3amalati.Data;
using Mou3amalati.Models;

namespace Mou3amalati.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CivilStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CivilStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CivilStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.CivilStatuses.ToListAsync());
        }

        // GET: CivilStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var civilStatus = await _context.CivilStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (civilStatus == null)
            {
                return NotFound();
            }

            return View(civilStatus);
        }

        // GET: CivilStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CivilStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description")] CivilStatus civilStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(civilStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(civilStatus);
        }

        // GET: CivilStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var civilStatus = await _context.CivilStatuses.FindAsync(id);
            if (civilStatus == null)
            {
                return NotFound();
            }
            return View(civilStatus);
        }

        // POST: CivilStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description")] CivilStatus civilStatus)
        {
            if (id != civilStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(civilStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CivilStatusExists(civilStatus.Id))
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
            return View(civilStatus);
        }

        // GET: CivilStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var civilStatus = await _context.CivilStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (civilStatus == null)
            {
                return NotFound();
            }

            return View(civilStatus);
        }

        // POST: CivilStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var civilStatus = await _context.CivilStatuses.FindAsync(id);
            _context.CivilStatuses.Remove(civilStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CivilStatusExists(int id)
        {
            return _context.CivilStatuses.Any(e => e.Id == id);
        }
    }
}
