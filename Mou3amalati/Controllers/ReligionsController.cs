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
    public class ReligionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReligionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Religions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Religions.ToListAsync());
        }

        // GET: Religions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var religion = await _context.Religions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (religion == null)
            {
                return NotFound();
            }

            return View(religion);
        }

        // GET: Religions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Religions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description")] Religion religion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(religion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(religion);
        }

        // GET: Religions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var religion = await _context.Religions.FindAsync(id);
            if (religion == null)
            {
                return NotFound();
            }
            return View(religion);
        }

        // POST: Religions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description")] Religion religion)
        {
            if (id != religion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(religion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReligionExists(religion.Id))
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
            return View(religion);
        }

        // GET: Religions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var religion = await _context.Religions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (religion == null)
            {
                return NotFound();
            }

            return View(religion);
        }

        // POST: Religions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var religion = await _context.Religions.FindAsync(id);
            _context.Religions.Remove(religion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReligionExists(int id)
        {
            return _context.Religions.Any(e => e.Id == id);
        }
    }
}
