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
    public class DocumentStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocumentStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DocumentStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.DocumentStatuses.ToListAsync());
        }

        // GET: DocumentStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentStatus = await _context.DocumentStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documentStatus == null)
            {
                return NotFound();
            }

            return View(documentStatus);
        }

        // GET: DocumentStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DocumentStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description")] DocumentStatus documentStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documentStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(documentStatus);
        }

        // GET: DocumentStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentStatus = await _context.DocumentStatuses.FindAsync(id);
            if (documentStatus == null)
            {
                return NotFound();
            }
            return View(documentStatus);
        }

        // POST: DocumentStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description")] DocumentStatus documentStatus)
        {
            if (id != documentStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documentStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentStatusExists(documentStatus.Id))
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
            return View(documentStatus);
        }

        // GET: DocumentStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentStatus = await _context.DocumentStatuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (documentStatus == null)
            {
                return NotFound();
            }

            return View(documentStatus);
        }

        // POST: DocumentStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var documentStatus = await _context.DocumentStatuses.FindAsync(id);
            _context.DocumentStatuses.Remove(documentStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentStatusExists(int id)
        {
            return _context.DocumentStatuses.Any(e => e.Id == id);
        }
    }
}
